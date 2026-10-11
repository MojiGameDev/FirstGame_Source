using UnityEngine;

namespace __SARV.Core.Extension
{
    public static class SVVectorExtension
    {
        public static bool HasValue(this Vector3 source)
        {
            return source.magnitude.HasValue();
        }
    }
}