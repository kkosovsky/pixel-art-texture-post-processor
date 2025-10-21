using UnityEditor;
using UnityEngine;

namespace PAT
{
    [CustomEditor(inspectedType: typeof(PATSettings))]
    class AssetPostprocessorSettingsEditor : Editor
    {
        const string buttonText = "Set Active";

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();

            GUILayout.Space(pixels: 10f);
            
            PATSettings thisSettings = (PATSettings)serializedObject.targetObject;
            
            if (thisSettings.isActive)
            {
                EditorGUILayout.HelpBox("This settings object is currently ACTIVE", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("This settings object is currently INACTIVE", MessageType.Warning);
            }
            
            if (GUILayout.Button(text: buttonText))
            {
                PATSettingsLoader.SetActiveSettings(settings: thisSettings);
                PATPostProcessor.SetActiveSettings(settings: thisSettings);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
