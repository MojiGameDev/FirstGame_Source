using __SARV.Core.Enum;
using UnityEngine;

namespace __SARV.Core.Utils
{
    public static class SVComponentUtils
    {
        public static void DebugLog(SVLogLevel logLevel, string logText)
        {
            switch (logLevel)
            {
                case SVLogLevel.Warning:
                    Debug.LogWarning(logText);
                    break;
                case SVLogLevel.Error:
                    Debug.LogError(logText);
                    break;
                case SVLogLevel.Info:
                default:
                    Debug.Log(logText);
                    break;
            }
        }
    }
}