using System;
using System.Text;

namespace PAT
{
    static class StringsFactory
    {
        static readonly StringBuilder stringBuilder = new();

        internal static string MakeInvalidPath(string assetPath)
        {
            stringBuilder.Clear();
            stringBuilder
                .Append(PAT_Const.Strings.invalidPath)
                .Append(assetPath);

            return stringBuilder.ToString();
        }

        internal static string MakeDefaultSettingsCreated(string assetPath)
        {
            stringBuilder.Clear();
            stringBuilder
                .Append(PAT_Const.Strings.defaultSettingsCreated)
                .Append(assetPath);

            return stringBuilder.ToString();
        }

        internal static string MakeFailedToLoadSettings(string errorMessage)
        {
            stringBuilder.Clear();
            stringBuilder
                .Append(PAT_Const.Strings.failedToLoadSettings)
                .Append(errorMessage);

            return stringBuilder.ToString();
        }

        internal static string MakeSuccess(string assetPath, PATSettings settings)
        {
            stringBuilder.Clear();
            stringBuilder
                .Append(PAT_Const.Strings.success)
                .Append(PAT_Const.Strings.JsonFormatting.newline)
                .Append(assetPath)
                .AppendLine();
            AppendSettings(settings: settings);

            return stringBuilder.ToString();
        }

        internal static string MakeSettingsActivated(string assetPath, PATSettings settings)
        {
            stringBuilder.Clear();
            stringBuilder
                .Append(PAT_Const.Strings.settingsActivated)
                .Append(PAT_Const.Strings.JsonFormatting.newline)
                .Append(assetPath)
                .AppendLine();
            AppendSettings(settings: settings);

            return stringBuilder.ToString();
        }

        static void AppendSettings(PATSettings settings)
        {
            stringBuilder.AppendLine(value: PAT_Const.Strings.JsonFormatting.openBrace);
            AppendJsonField(
                fieldName: PAT_Const.Strings.JsonFormatting.minTextureSizeField,
                value: settings.minTextureSize
            );
            AppendJsonField(fieldName: PAT_Const.Strings.JsonFormatting.ppuField, value: settings.PPU);
            AppendJsonField(
                fieldName: PAT_Const.Strings.JsonFormatting.isReadableField,
                value: settings.isReadable.ToString().ToLower()
            );
            AppendJsonField(
                fieldName: PAT_Const.Strings.JsonFormatting.postProcessOrderField,
                value: settings.postProcessOrder
            );

            AppendJsonArrayField(
                fieldName: PAT_Const.Strings.JsonFormatting.includePathsField,
                values: settings.includePaths
            );
            AppendJsonArrayField(
                fieldName: PAT_Const.Strings.JsonFormatting.excludePathsField,
                values: settings.excludePaths
            );
            AppendJsonArrayField(
                fieldName: PAT_Const.Strings.JsonFormatting.fullRectMeshSubstringsField,
                values: settings.fullRectMeshSubstrings
            );
            AppendJsonArrayField(
                fieldName: PAT_Const.Strings.JsonFormatting.fullRectMeshPathsField,
                values: settings.fullRectMeshPaths
            );
            AppendJsonArrayField(
                fieldName: PAT_Const.Strings.JsonFormatting.multipleSpriteModeSubstringsField,
                values: settings.multipleSpriteModeSubstrings
            );
            AppendJsonArrayField(
                fieldName: PAT_Const.Strings.JsonFormatting.multipleSpriteModPathsField,
                values: settings.multipleSpriteModePaths,
                isLast: true
            );

            stringBuilder.AppendLine(value: PAT_Const.Strings.JsonFormatting.closeBrace);
        }

        static void AppendJsonField(string fieldName, object value, bool isLast = false)
        {
            stringBuilder
                .Append(PAT_Const.Strings.JsonFormatting.indent)
                .Append(PAT_Const.Strings.JsonFormatting.quote)
                .Append(fieldName)
                .Append(PAT_Const.Strings.JsonFormatting.quote)
                .Append(PAT_Const.Strings.JsonFormatting.colonSpace)
                .Append(value);

            if (!isLast)
            {
                stringBuilder.Append(PAT_Const.Strings.JsonFormatting.comma);
            }

            stringBuilder.AppendLine();
        }

        static void AppendJsonArrayField(string fieldName, string[] values, bool isLast = false)
        {
            stringBuilder
                .Append(PAT_Const.Strings.JsonFormatting.indent)
                .Append(PAT_Const.Strings.JsonFormatting.quote)
                .Append(fieldName)
                .Append(PAT_Const.Strings.JsonFormatting.quote)
                .Append(PAT_Const.Strings.JsonFormatting.colonSpace)
                .Append(PAT_Const.Strings.JsonFormatting.openBracket);

            string[] valueStrings = values ?? Array.Empty<string>();
            for (int i = 0; i < valueStrings.Length; i++)
            {
                if (i > 0)
                {
                    stringBuilder.Append(PAT_Const.Strings.JsonFormatting.separator);
                }

                stringBuilder
                    .Append(PAT_Const.Strings.JsonFormatting.quote)
                    .Append(valueStrings[i])
                    .Append(PAT_Const.Strings.JsonFormatting.quote);
            }

            stringBuilder.Append(PAT_Const.Strings.JsonFormatting.closeBracket);

            if (!isLast)
            {
                stringBuilder.Append(PAT_Const.Strings.JsonFormatting.comma);
            }

            stringBuilder.AppendLine();
        }
    }
}
