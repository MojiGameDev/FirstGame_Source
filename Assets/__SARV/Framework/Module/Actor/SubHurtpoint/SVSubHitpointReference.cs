using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubHurtpoint
{
    public abstract class SVSubHitpointReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected Collider colliderPoint;

        [OnInspectorInit]
        private void InitialReference()
        {
            if (colliderPoint == null)
            {
                colliderPoint = GetComponent<Collider>();
            }
        }
    }
}