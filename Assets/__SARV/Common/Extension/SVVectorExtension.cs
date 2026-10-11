using UnityEngine;

namespace __SARV.Common.Extension
{
    public static class SVVectorExtension
    {
        public static bool HasValue(this Vector3 source)
        {
            return source.magnitude.HasValue();
        }
    }
}