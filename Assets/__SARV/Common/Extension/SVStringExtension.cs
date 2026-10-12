using System.Text.RegularExpressions;

namespace __SARV.Common.Extension
{
    public static class SVStringExtension
    {
        public static string ToPascalCase(this string value)
        {
            return char.ToUpperInvariant(value[0]) + value[1..];
        }
    }
}