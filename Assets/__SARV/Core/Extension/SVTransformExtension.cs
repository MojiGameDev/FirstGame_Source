using UnityEngine;

namespace __SARV.Core.Extension
{
    public static class SVTransformExtension
    {
        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
    }
}