using System;
using UnityEditor;

namespace PAT
{
    public static class PATSettingsLoader
    {
        public static PATSettings LoadSettings()
        {
            try
            {
                return LoadSettingsInternal();
            }
            catch (Exception ex)
            {
                PATLog.Error(message: $"Failed to load PAT Settings: {ex.Message}");
                return null;
            }
        }

        static PATSettings LoadSettingsInternal()
        {
            string[] guids = AssetDatabase.FindAssets(filter: $"t:{nameof(PATSettings)}");

            switch (guids.Length)
            {
                case 0:
                    PATLog.Warning(message: "No PATSettings found. Creating default settings.");
                    return PATDefaultSettingsFactory.MakeDefaultSettings();
                case > 1:
                    PATLog.Warning(message: $"Multiple PATSettings found ({guids.Length}). Using the first one.");
                    break;
            }

            string assetPath = AssetDatabase.GUIDToAssetPath(guid: guids[0]);
            PATSettings settings = AssetDatabase.LoadAssetAtPath<PATSettings>(assetPath: assetPath);

            if (settings == null)
            {
                PATLog.Error(message: $"Failed to load PATSettings from: {assetPath}");
                return PATDefaultSettingsFactory.MakeDefaultSettings();
            }

            PATLog.Success(message: $"PAT Settings loaded: {assetPath}");
            return settings;
        }

        public static PATSettings LoadFromPath(string path)
        {
            PATSettings settings = AssetDatabase.LoadAssetAtPath<PATSettings>(assetPath: path);

            if (settings != null)
            {
                PATLog.Success(message: $"PAT Settings loaded from: {path}");
            }
            else
            {
                PATLog.Error(message: $"Failed to load PAT Settings from: {path}");
            }

            return settings;
        }
    }
}
