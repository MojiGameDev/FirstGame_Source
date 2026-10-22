using __SARV.Framework.Module.Raycast.Entity;
using UnityEngine;

namespace __SARV.Framework.Module.Raycast
{
    public class SVRaycast
    {
        public static bool Try(Vector3 position, float distance, LayerMask layerMask, out SVRaycastResult raycastResult)
        {
            raycastResult = null;
            if (Physics.Raycast(new Ray(position, Vector3.down), out var hitInfo, distance, layerMask))
            {
                raycastResult = new SVRaycastResult(hitInfo.transform, hitInfo.point, hitInfo.normal, hitInfo.triangleIndex, hitInfo.textureCoord);
                return true;
            }

            return false;
        }
    }
}