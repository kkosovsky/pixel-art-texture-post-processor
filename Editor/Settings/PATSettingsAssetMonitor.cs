using UnityEditor;

namespace PAT
{
    class PATSettingsAssetMonitor : AssetModificationProcessor
    {
        static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        {
            PATSettings settings = AssetDatabase.LoadAssetAtPath<PATSettings>(assetPath: assetPath);
            if (settings == null)
            {
                return AssetDeleteResult.DidNotDelete;
            }

            PATPostProcessor.OnSettingsDeleted(deletedSettings: settings);
            return AssetDeleteResult.DidNotDelete;
        }
    }
}
