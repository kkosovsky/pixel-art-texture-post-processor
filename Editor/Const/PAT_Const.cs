namespace PAT
{
    static class PAT_Const
    {
        internal static class Strings
        {
            internal static string assets = "Assets";
            internal const string invalidPath = "Invalid Path: ";
            internal const string success = "PixelArtPostprocessor finished with succes!";

            internal static class Reflection
            {
                internal const string getWidthAndHeight = "GetWidthAndHeight";
            }
        }

        internal static class DefaultSettings
        {
            // Base Settings
            internal const int minTextureSize = 32;
            internal const int PPU = 32;
            internal const bool isReadable = true;
            internal const int postProcessOrder = 0;

            // Paths
            internal const string assetPath = "Assets/PixelArtTexturePostProcessor/Editor/Settings/Assets/PAT_DefaultSettings.asset";
            
            internal static readonly string[] includePaths = { "Assets/Sprites/" };
            internal static readonly string[] excludePaths = { 
                "Packages/",
                "Assets/Gizmos/",
                "Assets/StreamingAssets/"
            };
            
            internal static readonly string[] fullRectMeshSubstrings = { "9Slice" };
            internal static readonly string[] fullRectMeshPaths = System.Array.Empty<string>();
            
            internal static readonly string[] multipleSpriteModeSubstrings = { "Animation" };
            internal static readonly string[] multipleSpriteModePaths = System.Array.Empty<string>();
        }
    }
}
