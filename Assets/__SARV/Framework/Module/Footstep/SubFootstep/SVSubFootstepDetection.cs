using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepDetection : SVSubFootstepPlay
    {
        [BoxGroup("Detection")] [SerializeField] [PropertyRange(0.1f, 1f)]
        protected float raycastDistance = 0.5f;

        [BoxGroup("Detection")] [SerializeField] private LayerMask groundLayer;

        protected bool IsFootGrounded(Transform footTransform, out RaycastHit hit)
        {
            var origin = footTransform.position + Vector3.up;
            return Physics.Raycast(origin, Vector3.down, out hit, raycastDistance, groundLayer);
        }
    }
}