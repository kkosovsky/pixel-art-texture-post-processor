namespace PAT
{
    static class PAT_Const
    {
        internal static class Strings
        {
            internal const string invalidPath = "Invalid Path: ";
            internal const string success = "PixelArtPostprocessor finished with succes!";
            internal const string noSettingsFoundCreatingDefault = "No PATSettings found. Creating default settings.";
            internal const string settingsActivated = "PAT Settings Activated: ";
            internal const string failedToLoadSettings = "Failed to load PAT Settings: ";
            internal const string defaultSettingsCreated = "Default PAT Settings created at: ";
            internal static readonly string assetFilter = $"t:{nameof(PATSettings)}";
            
            internal static class Reflection
            {
                internal const string getWidthAndHeight = "GetWidthAndHeight";
            }

            internal static class UI
            {
                internal const string setActiveButton = "Set Active";
                internal const string settingsActiveInfo = "This settings object is currently ACTIVE";
                internal const string settingsInactiveWarning = "This settings object is currently INACTIVE";
            }

            internal static class CreateAssetMenu
            {
                internal const string fileName = "PixelArtTextureSettings";
                internal const string menuName = "PixelArtPostProcessor/Settings";
            }

            internal static class Headers
            {
                internal const string baseSettings = "Base Settings";
                internal const string mainPaths = "Main Paths";
                internal const string fullRectMeshType = "Full Rect Mesh Type";
                internal const string multipleSpriteMode = "Multiple Sprite Mode";
            }

            internal static class LogFormatting
            {
                internal const string successFormat = "<color=green>\u2705 {0}</color>";
                internal const string errorFormat = "<color=red>\u274c {0}</color>";
                internal const string warningFormat = "<color=yellow>\u26a0\ufe0f {0}</color>";
                internal const string infoFormat = "<color=cyan>ℹ\ufe0f {0}</color>";
                internal const string criticalFormat = "<color=red><b>\ud83d\udea8 CRITICAL: {0}</b></color>";
                internal const string progressFormat = "<color=cyan>\ud83d\udcc8 {0}: <b>{1:P0}</b> {2}</color>";
                internal const string methodFormat = "<color=magenta>\ud83d\udd27 Method: <b>{0}</b></color>";
                
                internal const char progressBarFilled = '█';
                internal const char progressBarEmpty = '░';
                
                internal const string colorRed = "red";
                internal const string colorYellow = "yellow";
                internal const string colorGreen = "green";
                
                internal const string performanceFormatTemplate = "<color={0}>\u23f1\ufe0f {1}: <b>{2:F2}ms</b></color>";
            }

            internal static class JsonFormatting
            {
                // Structural characters
                internal const string openBrace = "{";
                internal const string closeBrace = "}";
                internal const string openBracket = "[";
                internal const string closeBracket = "]";
                internal const string comma = ",";
                internal const string empty = "";
                internal const string indent = "  ";
                internal const string colonSpace = ": ";
                internal const string separator = ", ";
                internal const string quote = "\"";
                internal const string newline = "\n";
                
                // Field names
                internal const string minTextureSizeField = "minTextureSize";
                internal const string ppuField = "PPU";
                internal const string isReadableField = "isReadable";
                internal const string postProcessOrderField = "postProcessOrder";
                internal const string includePathsField = "includePaths";
                internal const string excludePathsField = "excludePaths";
                internal const string fullRectMeshSubstringsField = "fullRectMeshSubstrings";
                internal const string fullRectMeshPathsField = "fullRectMeshPaths";
                internal const string multipleSpriteModeSubstringsField = "multipleSpriteModeSubstrings";
                internal const string multipleSpriteModPathsField = "multipleSpriteModePaths";
            }
        }

        internal static class DefaultSettings
        {
            internal const int minTextureSize = 32;
            internal const int PPU = 32;
            internal const bool isReadable = true;
            internal const int postProcessOrder = 0;

            internal const string assetPath =
                "Assets/PixelArtTexturePostProcessor/Editor/Settings/Assets/PAT_DefaultSettings.asset";

            internal static readonly string[] includePaths = { "Assets/Sprites/" };

            internal static readonly string[] excludePaths =
            {
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
