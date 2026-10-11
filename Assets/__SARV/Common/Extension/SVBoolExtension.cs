namespace __SARV.Common.Extension
{
    public static class SVBoolExtension
    {
        public static string ToName(this bool value)
        {
            return value ? "True" : "False";
        }
    }
}