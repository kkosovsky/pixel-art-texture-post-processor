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
                EditorGUILayout.HelpBox(message: PAT_Const.Strings.UI.settingsActiveInfo, type: MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox(message: PAT_Const.Strings.UI.settingsInactiveWarning, type: MessageType.Warning);
            }
            
            if (GUILayout.Button(text: PAT_Const.Strings.UI.setActiveButton))
            {
                PATSettingsLoader.SetActiveSettings(settings: thisSettings);
                PATPostProcessor.SetActiveSettings(settings: thisSettings);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
