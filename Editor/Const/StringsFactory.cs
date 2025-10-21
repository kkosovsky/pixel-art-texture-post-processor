using System;
using System.Linq;
using System.Text;

namespace PAT
{
    static class StringsFactory
    {
        static readonly StringBuilder stringBuilder = new();

        internal static string MakeInvalidPath(string assetPath)
        {
            return $"{PAT_Const.Strings.invalidPath}{assetPath}!";
        }

        internal static string MakeSuccess(string assetPath, PATSettings settings)
        {
            return $"{PAT_Const.Strings.success}\n{assetPath}\n{MakeSettings(settings: settings)}!";
        }

        internal static string MakeSettings(PATSettings settings)
        {
            stringBuilder.Clear();
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"  \"minTextureSize\": {settings.minTextureSize},");
            stringBuilder.AppendLine($"  \"PPU\": {settings.PPU},");
            stringBuilder.AppendLine($"  \"isReadable\": {settings.isReadable.ToString().ToLower()},");
            stringBuilder.AppendLine($"  \"postProcessOrder\": {settings.postProcessOrder},");

            stringBuilder.AppendLine(
                $"  \"includePaths\": [{string.Join(", ", (settings.includePaths ?? Array.Empty<string>()).Select(p => $"\"{p}\""))}],"
            );
            stringBuilder.AppendLine(
                $"  \"excludePaths\": [{string.Join(", ", (settings.excludePaths ?? Array.Empty<string>()).Select(p => $"\"{p}\""))}],"
            );
            stringBuilder.AppendLine(
                $"  \"fullRectMeshSubstrings\": [{string.Join(", ", (settings.fullRectMeshSubstrings ?? Array.Empty<string>()).Select(s => $"\"{s}\""))}],"
            );
            stringBuilder.AppendLine(
                $"  \"fullRectMeshPaths\": [{string.Join(", ", (settings.fullRectMeshPaths ?? Array.Empty<string>()).Select(p => $"\"{p}\""))}],"
            );
            stringBuilder.AppendLine(
                $"  \"multipleSpriteModeSubstrings\": [{string.Join(", ", (settings.multipleSpriteModeSubstrings ?? Array.Empty<string>()).Select(s => $"\"{s}\""))}],"
            );
            stringBuilder.AppendLine(
                $"  \"multipleSpriteModePaths\": [{string.Join(", ", (settings.multipleSpriteModePaths ?? Array.Empty<string>()).Select(p => $"\"{p}\""))}]"
            );
            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }
    }
}
