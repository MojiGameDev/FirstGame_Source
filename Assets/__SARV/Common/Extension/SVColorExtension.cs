using UnityEngine;

namespace __SARV.Common.Extension
{
    public static class SVColorExtension
    {
        public static string ToHexString(this Color color)
        {
            return
                ((byte)(color.r * 255)).ToString("X2") +
                ((byte)(color.g * 255)).ToString("X2") +
                ((byte)(color.b * 255)).ToString("X2");
        }
    }
}