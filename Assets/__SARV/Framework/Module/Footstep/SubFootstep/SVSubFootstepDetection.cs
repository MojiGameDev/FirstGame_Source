using System;
using __SARV.Framework.Module.Raycast;
using __SARV.Framework.Module.Raycast.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepDetection : SVSubFootstepSurface
    {
        [BoxGroup("Detection")] [SerializeField] [PropertyRange(0.1f, 1f)]
        protected float raycastDistance = 0.5f;

        [BoxGroup("Detection")] [SerializeField]
        private LayerMask groundLayer;

        protected bool IsFootGrounded(Transform footTransform, out SVRaycastResult raycastResult)
        {
            var isGrounded = SVRaycast.Try(footTransform.position, raycastDistance, groundLayer, out raycastResult);
            return isGrounded;
        }
    }
}