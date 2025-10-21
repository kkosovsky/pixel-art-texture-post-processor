using System;
using System.Linq;
using UnityEditor;

namespace PAT
{
    static class PATSettingsLoader
    {
        internal static PATSettings LoadSettings()
        {
            try
            {
                return LoadSettingsInternal();
            }
            catch (Exception ex)
            {
                PATLog.Error(message: StringsFactory.MakeFailedToLoadSettings(errorMessage: ex.Message));
                return null;
            }
        }

        internal static void SetActiveSettings(PATSettings settings)
        {
            string[] guids = AssetDatabase.FindAssets(filter: PAT_Const.Strings.assetFilter);
            PATSettings[] allSettings = LoadAllSettings(guids: guids);
            DeactivateAllExcept(allSettings: allSettings, exception: settings);
            Activate(settings: settings);
            AssetDatabase.SaveAssets();
        }

        static PATSettings LoadSettingsInternal()
        {
            string[] guids = AssetDatabase.FindAssets(filter: PAT_Const.Strings.assetFilter);
            
            if (guids.Length == 0)
            {
                PATLog.Warning(message: PAT_Const.Strings.noSettingsFoundCreatingDefault);
                PATSettings settings =  PATDefaultSettingsFactory.MakeDefaultSettings();
                AssetDatabase.SaveAssets();
                return settings;
            }

            PATSettings[] allSettings = LoadAllSettings(guids: guids);

            if (allSettings.Any(predicate: settings => settings.isActive))
            {
                PATSettings firstActiveSettings = allSettings.First(predicate: settings => settings.isActive);
                DeactivateAllExcept(allSettings: allSettings, exception: firstActiveSettings);
                AssetDatabase.SaveAssets();
                return firstActiveSettings;
            }

            PATSettings firstSettings = allSettings[0];
            DeactivateAllExcept(allSettings: allSettings, exception: firstSettings);
            Activate(settings: firstSettings);
            AssetDatabase.SaveAssets();

            return firstSettings;
        }

        static PATSettings[] LoadAllSettings(string[] guids)
        {
            PATSettings[] allSettings = new PATSettings[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid: guids[i]);
                allSettings[i] = AssetDatabase.LoadAssetAtPath<PATSettings>(assetPath: assetPath);
            }

            return allSettings;
        }

        static void DeactivateAllExcept(PATSettings[] allSettings, PATSettings exception)
        {
            foreach (PATSettings settings in allSettings)
            {
                if (settings == exception)
                {
                    continue;
                }

                settings.isActive = false;
                EditorUtility.SetDirty(target: settings);
            }
        }

        static void Activate(PATSettings settings)
        {
            if (settings.isActive)
            {
                return;
            }

            settings.isActive = true;
            EditorUtility.SetDirty(target: settings);
            PATLog.Success(
                message: StringsFactory.MakeSettingsActivated(
                    assetPath: AssetDatabase.GetAssetPath(assetObject: settings),
                    settings: settings
                )
            );
        }
    }
}
