using System;

namespace __SARV.Common.Extension
{
    public static class SVStringExtension
    {
        public static string ToPascalCase(this string value)
        {
            return char.ToUpperInvariant(value[0]) + value[1..];
        }

        /// <summary>
        /// Enemy_Modular_01_MeleeWeapon_Sword_01 => Sword_01
        /// Modular_01_MeleeWeapon_Bow_01 => Bow_01
        /// Boss_01_MeleeWeapon_Bow_01_B => Bow_01_B
        /// Boss_01_MeleeWeapon_Sword_01_A => Sword_01_A
        /// </summary>
        public static string ToSpecificName(this string value)
        {
            var parts = value.Split('_');

            if (parts.Length < 2)
            {
                return value;
            }

            var result = $"{parts[^2]}_{parts[^1]}";
            if (parts.Length >= 3 && parts[^1].Length == 1 && char.IsLetter(parts[^1][0]))
            {
                result = $"{parts[^3]}_{parts[^2]}_{parts[^1]}";
            }

            return result;
        }
    }
}