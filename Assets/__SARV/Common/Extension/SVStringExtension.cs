using System;

namespace __SARV.Common.Extension
{
    public static class SVStringExtension
    {
        public static string ToPascalCase(this string value)
        {
            return char.ToUpperInvariant(value[0]) + value[1..];
        }

        public static string ToWeaponName(this string value)
        {
            const string prefix = "Weapon_";

            var index = value.IndexOf(prefix, StringComparison.Ordinal);

            return index >= 0 ? value[(index + prefix.Length)..] : string.Empty;
        }

        public static string ToShieldName(this string value)
        {
            const string prefix = "Shield_";

            var index = value.IndexOf(prefix, StringComparison.Ordinal);

            return index >= 0 ? value[(index + prefix.Length)..] : string.Empty;
        }
    }
}