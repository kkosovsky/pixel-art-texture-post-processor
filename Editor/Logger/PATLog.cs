namespace PAT
{
    using UnityEngine;

    static class PATLog
    {
        internal static void Success(object message, Object context = null)
        {
            Debug.Log(message: string.Format(PAT_Const.Strings.LogFormatting.successFormat, message), context: context);
        }

        internal static void Error(object message, Object context = null)
        {
            Debug.Log(message: string.Format(PAT_Const.Strings.LogFormatting.errorFormat, message), context: context);
        }

        internal static void Warning(object message, Object context = null)
        {
            Debug.Log(message: string.Format(PAT_Const.Strings.LogFormatting.warningFormat, message), context: context);
        }

        internal static void Info(object message, Object context = null)
        {
            Debug.Log(message: string.Format(PAT_Const.Strings.LogFormatting.infoFormat, message), context: context);
        }

        internal static void Critical(object message, Object context = null)
        {
            Debug.Log(message: string.Format(PAT_Const.Strings.LogFormatting.criticalFormat, message), context: context);
        }

        internal static void Progress(string operation, float progress, Object context = null)
        {
            int bars = Mathf.RoundToInt(f: progress * 10);
            string progressBar = new string(c: PAT_Const.Strings.LogFormatting.progressBarFilled, count: bars) 
                + new string(c: PAT_Const.Strings.LogFormatting.progressBarEmpty, count: 10 - bars);
            Debug.Log(
                message: string.Format(
                    format: PAT_Const.Strings.LogFormatting.progressFormat,
                    arg0: operation,
                    arg1: progress,
                    arg2: progressBar
                ),
                context: context
            );
        }

        internal static void Method(string methodName, Object context = null)
        {
            Debug.Log(message: string.Format(PAT_Const.Strings.LogFormatting.methodFormat, methodName), context: context);
        }

        internal static void Performance(string operation, float milliseconds, Object context = null)
        {
            string color = milliseconds > 16 
                ? PAT_Const.Strings.LogFormatting.colorRed 
                : milliseconds > 8 
                    ? PAT_Const.Strings.LogFormatting.colorYellow 
                    : PAT_Const.Strings.LogFormatting.colorGreen;
            Debug.Log(
                message: string.Format(PAT_Const.Strings.LogFormatting.performanceFormatTemplate, color, operation, milliseconds),
                context: context
            );
        }
    }
}
