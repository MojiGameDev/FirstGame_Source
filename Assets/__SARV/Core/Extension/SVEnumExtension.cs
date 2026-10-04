namespace __SARV.Core.Extension
{
    public static class SVEnumExtension
    {
        public static string ToReadableString(this System.Enum value)
        {
            return System.Text.RegularExpressions.Regex
                .Replace(value.ToString(), "(\\B[A-Z])", " $1")
                .ToLowerInvariant();
        }
    }
}