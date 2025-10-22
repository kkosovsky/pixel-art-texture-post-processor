namespace PAT
{
    static class PAT_Const
    {
        internal static class Strings
        {
            internal const string invalidPath = "Invalid Path: ";
            internal const string success = "PAT finished with success!";
            internal const string noSettingsFoundCreatingDefault = "No PATSettings found. Creating default settings.";
            internal const string settingsActivated = "PAT Settings Activated!";
            internal const string settingsDeactivated = "PAT Settings Dectivated! There is no issue, PAT PostProcessor will simply skip work if there are no active settings.";
            internal const string noSettingsActivatedSkipping = "There are no active PATSettings. Skipping work.";
            internal const string failedToLoadSettings = "Failed to load PAT Settings: ";
            internal const string failedToLoadSettingsAtPath = "Failed to load PATSettings at path: ";
            internal const string defaultSettingsCreated = "Default PAT Settings created at: ";
            internal const string getWidthAndHeightNotFound = "GetWidthAndHeight method not found - Unity API may have changed";
            internal const string failedToGetTextureSize = "Failed to get texture size via reflection: ";
            internal const string settingsDeletedWarning = "Activate PAT Settings deleted. PAT Postprocessor is now inactive.";
            internal static readonly string assetFilter = $"t:{nameof(PATSettings)}";

            internal static class Reflection
            {
                internal const string getWidthAndHeight = "GetWidthAndHeight";
            }

            internal static class UI
            {
                internal const string activateSettingsButton = "Activate Settings";
                internal const string deactivateSettingsButton = "Deactivate Settings";
                internal const string settingsActiveInfo = "This settings object is currently ACTIVE";
                internal const string settingsInactiveWarning = "This settings object is currently INACTIVE";
            }

            internal static class MenuItem
            {
                internal const string createDefaultSettings = "Tools/PAT Post Processor/Create Default Settings";
                internal const string saveDialogTitle = "Save Default PAT Settings";
                internal const string saveDialogMessage = "Choose where to save the default PAT Settings";
            }

            internal static class CreateAssetMenu
            {
                internal const string fileName = "PixelArtTextureSettings";
                internal const string menuName = "PAT Post Processor/Settings";
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
            }

            internal static class JsonFormatting
            {
                // Structural characters
                internal const string openBrace = "{";
                internal const string closeBrace = "}";
                internal const string openBracket = "[";
                internal const string closeBracket = "]";
                internal const string comma = ",";
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

            internal const string initialDefaultSettingsPath =
                "Assets/PAT_DefaultSettings.asset";

            internal static readonly string[] includePaths = { "Assets/Sprites/" };

            internal static readonly string[] excludePaths =
            {
                "Packages/",
                "Assets/Gizmos/",
                "Assets/StreamingAssets/"
            };

            internal static readonly string[] fullRectMeshSubstrings = { "9Slice" };
            internal static readonly string[] fullRectMeshPaths = System.Array.Empty<string>();

            internal static readonly string[] multipleSpriteModeSubstrings = { "Animation", "Anim" };
            internal static readonly string[] multipleSpriteModePaths = System.Array.Empty<string>();
        }
    }
}
