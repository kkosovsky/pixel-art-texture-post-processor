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
    }
}
