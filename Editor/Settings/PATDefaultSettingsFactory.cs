using UnityEditor;
using UnityEngine;

namespace PAT
{
    static class PATDefaultSettingsFactory
    {
        internal static PATSettings MakeDefaultActiveSettings() =>
            MakeDefaultSettings(path: PAT_Const.DefaultSettings.initialDefaultSettingsPath, isActive: true);

        static PATSettings MakeDefaultSettings(string path, bool isActive)
        {
            PATSettings settings = ScriptableObject.CreateInstance<PATSettings>();

            settings.isActive = isActive;
            settings.minTextureSize = PAT_Const.DefaultSettings.minTextureSize;
            settings.PPU = PAT_Const.DefaultSettings.PPU;
            settings.isReadable = PAT_Const.DefaultSettings.isReadable;
            settings.postProcessOrder = PAT_Const.DefaultSettings.postProcessOrder;

            settings.includePaths = PAT_Const.DefaultSettings.includePaths;
            settings.excludePaths = PAT_Const.DefaultSettings.excludePaths;

            settings.fullRectMeshSubstrings = PAT_Const.DefaultSettings.fullRectMeshSubstrings;
            settings.fullRectMeshPaths = PAT_Const.DefaultSettings.fullRectMeshPaths;

            settings.multipleSpriteModeSubstrings = PAT_Const.DefaultSettings.multipleSpriteModeSubstrings;
            settings.multipleSpriteModePaths = PAT_Const.DefaultSettings.multipleSpriteModePaths;

            AssetDatabase.CreateAsset(asset: settings, path: path);
            PATLog.Success(
                message: StringsFactory.MakeDefaultSettingsCreated(
                    assetPath: PAT_Const.DefaultSettings.initialDefaultSettingsPath
                )
            );

            return settings;
        }

        [MenuItem(itemName: PAT_Const.Strings.MenuItem.createDefaultSettings)]
        static void CreateDefaultSettingsMenuItem()
        {
            string path = EditorUtility.SaveFilePanelInProject(
                title: PAT_Const.Strings.MenuItem.saveDialogTitle,
                defaultName: PAT_Const.Strings.CreateAssetMenu.fileName,
                extension: "asset",
                message: PAT_Const.Strings.MenuItem.saveDialogMessage
            );

            if (string.IsNullOrEmpty(value: path))
            {
                return;
            }

            PATSettings settings = MakeDefaultSettings(path: path, isActive: false);
            EditorGUIUtility.PingObject(obj: settings);
            Selection.activeObject = settings;
        }
    }
}
