using UnityEngine;

namespace __SARV.Common.Extension
{
    public static class SVNumberExtension
    {
        public const float DEFAULT_THRESHOLD = 0.001f;

        public static bool HasValue(this float value)
        {
            return value > DEFAULT_THRESHOLD;
        }
        
        public static bool ApproximatelyEquals(this float f1, float f2)
        {
            return Mathf.Approximately(f1, f2);
        }
    }
}