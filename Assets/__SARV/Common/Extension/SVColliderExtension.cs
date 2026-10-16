using UnityEngine;

namespace __SARV.Common.Extension
{
    public static class SVColliderExtension
    {
        public static bool IsLayerDetected(this Collider collider, string layerName)
        {
            return LayerMask.LayerToName(collider.gameObject.layer) == layerName;
        }
    }
}