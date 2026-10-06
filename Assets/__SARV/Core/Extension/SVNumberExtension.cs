namespace __SARV.Core.Extension
{
    public static class SVNumberExtension
    {
        public const float DEFAULT_THRESHOLD = 0.001f;

        public static bool HasValue(this float value)
        {
            return value > DEFAULT_THRESHOLD;
        }
    }
}