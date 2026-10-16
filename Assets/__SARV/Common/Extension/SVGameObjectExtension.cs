using UnityEngine;

namespace __SARV.Common.Extension
{
    public static class SVGameObjectExtension
    {
        public static void Active(this GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Inactive(this GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public static void LocalScaleToZero(this GameObject gameObject)
        {
            gameObject.transform.localScale = Vector3.zero;
        }
    }
}