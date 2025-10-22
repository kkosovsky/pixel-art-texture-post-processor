using UnityEditor;
using UnityEngine;

namespace PAT
{
    static class PATDefaultSettingsFactory
    {
        internal static PATSettings MakeDefaultSettings()
        {
            PATSettings settings = ScriptableObject.CreateInstance<PATSettings>();

            settings.isActive = true;
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

            AssetDatabase.CreateAsset(asset: settings, path: PAT_Const.DefaultSettings.initialDefaultSettingsPath);
            PATLog.Success(
                message: StringsFactory.MakeDefaultSettingsCreated(assetPath: PAT_Const.DefaultSettings.initialDefaultSettingsPath)
            );
            return settings;
        }
    }
}
