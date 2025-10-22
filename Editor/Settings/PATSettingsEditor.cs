using UnityEditor;
using UnityEngine;

namespace PAT
{
    [CustomEditor(inspectedType: typeof(PATSettings))]
    class AssetPostprocessorSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();

            GUILayout.Space(pixels: 10f);
            PATSettings thisSettings = (PATSettings)serializedObject.targetObject;
            
            if (thisSettings.isActive)
            {
                ShowDeactivationGUI(settings: thisSettings);
            }
            else
            {
                ShowActivationGUI(settings: thisSettings);
            }
            
            serializedObject.ApplyModifiedProperties();
        }

        static void ShowDeactivationGUI(PATSettings settings)
        {
            EditorGUILayout.HelpBox(message: PAT_Const.Strings.UI.settingsActiveInfo, type: MessageType.Info);
            if (GUILayout.Button(text: PAT_Const.Strings.UI.deactivateSettingsButton))
            {
                DeactivateSettings(settings: settings);
            }
        }

        static void ShowActivationGUI(PATSettings settings)
        {
            EditorGUILayout.HelpBox(message: PAT_Const.Strings.UI.settingsInactiveWarning, type: MessageType.Warning);
            if (GUILayout.Button(text: PAT_Const.Strings.UI.activateSettingsButton))
            {
                ActivateSettings(settings: settings);
            }
        }

        static void DeactivateSettings(PATSettings settings)
        {
            PATSettingsLoader.DeactivateSettings(settings: settings);
            PATPostProcessor.DeactivateSettings(settings: settings);
        }

        static void ActivateSettings(PATSettings settings)
        {
            PATSettingsLoader.ActivateSettings(settings: settings);
            PATPostProcessor.ActivateSettings(settings: settings);
        }
    }
}
