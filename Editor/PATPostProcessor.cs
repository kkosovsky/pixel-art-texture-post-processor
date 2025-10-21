using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PAT
{
    public class PATPostProcessor : AssetPostprocessor
    {
        #region Lifecycle

        [InitializeOnLoadMethod]
        static void Initialize()
        {
            settings = PATSettingsLoader.LoadSettings();
        }

        #endregion

        #region Apply Settings

        static PATSettings settings;

        internal static void SetActiveSettings(PATSettings settings)
        {
            PATPostProcessor.settings = settings;
        }

        #endregion

        #region AssetPostprocessor

        public override int GetPostprocessOrder() => settings != null ? settings.postProcessOrder : 0;

        void OnPreprocessTexture()
        {
            if (!IsValidPath())
            {
                PATLog.Warning(message: StringsFactory.MakeInvalidPath(assetPath: assetPath));
                return;
            }

            TextureImporter textureImporter = (TextureImporter)assetImporter;
            TextureImporterSettings importerSettings = new();
            textureImporter.ReadTextureSettings(dest: importerSettings);
            importerSettings.spriteMeshType = GetSpriteMeshType();
            importerSettings.spriteMode = (int)GetSpriteMode();
            textureImporter.SetTextureSettings(src: importerSettings);

            textureImporter.isReadable = settings.isReadable;
            textureImporter.spritePixelsPerUnit = settings.PPU;
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
            textureImporter.filterMode = FilterMode.Point;

            int textureSize = GetTextureSize(importer: textureImporter);
            textureImporter.maxTextureSize = GetNearestPowerOfTwo(value: textureSize);
            PATLog.Success(message: StringsFactory.MakeSuccess(assetPath: assetPath, settings: settings));
        }

        #endregion

        #region Private

        bool IsValidPath()
        {
            return assetPath.ContainsAnySubstring(substrings: settings.includePaths)
                && !assetPath.ContainsAnySubstring(substrings: settings.excludePaths);
        }

        SpriteMeshType GetSpriteMeshType()
        {
            bool isFullRect = assetPath.ContainsAnySubstring(substrings: settings.fullRectMeshPaths)
                || assetPath.ContainsAnySubstring(substrings: settings.fullRectMeshSubstrings);

            return isFullRect ? SpriteMeshType.FullRect : SpriteMeshType.Tight;
        }

        SpriteImportMode GetSpriteMode()
        {
            bool isMultipleMode = assetPath.ContainsAnySubstring(substrings: settings.multipleSpriteModePaths)
                || assetPath.ContainsAnySubstring(substrings: settings.multipleSpriteModeSubstrings);

            return isMultipleMode ? SpriteImportMode.Multiple : SpriteImportMode.Single;
        }

        static int GetTextureSize(TextureImporter importer)
        {
            object[] args = { 0, 0 };
            MethodInfo methodInfo = typeof(TextureImporter).GetMethod(
                name: PAT_Const.Strings.Reflection.getWidthAndHeight,
                bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance
            );
            methodInfo.Invoke(obj: importer, parameters: args);

            int width = (int)args[0];
            int height = (int)args[1];

            return Math.Max(val1: width, val2: height);
        }

        static int GetNearestPowerOfTwo(int value) => value <= settings.minTextureSize
            ? settings.minTextureSize
            : Mathf.NextPowerOfTwo(value: value);

        #endregion
    }
}
