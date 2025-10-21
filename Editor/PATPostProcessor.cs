using System;
using System.Linq;
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

        internal static void ApplySettings(PATSettings settings)
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
                if (assetPath.Contains(PAT_Const.Strings.assets))
                {
                    PATLog.Info(message: StringsFactory.MakeInvalidPath(assetPath: assetPath));
                }
                
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
            return settings.includePaths.Contains(value: assetPath)
                && !settings.excludePaths.Contains(value: assetPath);
        }

        SpriteMeshType GetSpriteMeshType()
        {
            bool isFullRect = settings.fullRectMeshPaths.Contains(value: assetPath)
                || assetPath.ContainsAnySubstring(substrings: settings.fullRectMeshSubstrings);

            return isFullRect ? SpriteMeshType.FullRect : SpriteMeshType.Tight;
        }

        SpriteImportMode GetSpriteMode()
        {
            bool isMultipleMode = settings.multipleSpriteModePaths.Contains(value: assetPath)
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
