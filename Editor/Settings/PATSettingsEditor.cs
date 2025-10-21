using UnityEditor;
using UnityEngine;

namespace PAT
{
    [CustomEditor(inspectedType: typeof(PATSettings))]
    class AssetPostprocessorSettingsEditor : Editor
    {
        const string buttonText = "Apply Settings";

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();

            GUILayout.Space(pixels: 10f);
            if (GUILayout.Button(text: buttonText))
            {
                if (serializedObject.targetObject is PATSettings settings)
                {
                    PATPostProcessor.ApplySettings(settings: settings);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
