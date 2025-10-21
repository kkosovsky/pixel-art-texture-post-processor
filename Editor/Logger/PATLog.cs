namespace PAT
{
    using UnityEngine;

    static class PATLog
    {
        internal static void Success(object message, Object context = null)
        {
            Debug.Log(message: $"<color=green>\u2705 {message}</color>", context: context);
        }

        internal static void Error(object message, Object context = null)
        {
            Debug.Log(message: $"<color=red>\u274c {message}</color>", context: context);
        }

        internal static void Warning(object message, Object context = null)
        {
            Debug.Log(message: $"<color=yellow>\u26a0\ufe0f {message}</color>", context: context);
        }

        internal static void Info(object message, Object context = null)
        {
            Debug.Log(message: $"<color=cyan>ℹ\ufe0f {message}</color>", context: context);
        }

        internal static void Critical(object message, Object context = null)
        {
            Debug.Log(message: $"<color=red><b>\ud83d\udea8 CRITICAL: {message}</b></color>", context: context);
        }

        internal static void Progress(string operation, float progress, Object context = null)
        {
            int bars = Mathf.RoundToInt(f: progress * 10);
            string progressBar = new string(c: '█', count: bars) + new string(c: '░', count: 10 - bars);
            Debug.Log(
                message: string.Format(
                    format: "<color=cyan>\ud83d\udcc8 {0}: <b>{1:P0}</b> {2}</color>",
                    arg0: operation,
                    arg1: progress,
                    arg2: progressBar
                ),
                context: context
            );
        }

        internal static void Method(string methodName, Object context = null)
        {
            Debug.Log(message: $"<color=magenta>\ud83d\udd27 Method: <b>{methodName}</b></color>", context: context);
        }

        internal static void Performance(string operation, float milliseconds, Object context = null)
        {
            string color = milliseconds > 16 ? "red" : milliseconds > 8 ? "yellow" : "green";
            Debug.Log(
                message: $"<color={color}>\u23f1\ufe0f {operation}: <b>{milliseconds:F2}ms</b></color>",
                context: context
            );
        }
    }
}
