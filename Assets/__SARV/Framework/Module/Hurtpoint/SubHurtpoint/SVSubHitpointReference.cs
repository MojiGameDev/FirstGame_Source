using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Hurtpoint.SubHurtpoint
{
    public abstract class SVSubHitpointReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected Collider colliderPoint;

        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected Rigidbody rigidbodyPoint;
        
        public Rigidbody RigidbodyPoint => rigidbodyPoint;

        protected override void Awake()
        {
            base.Awake();
            InitialReference();
        }

        [OnInspectorInit]
        private void InitialReference()
        {
            if (colliderPoint == null)
            {
                colliderPoint = GetComponent<Collider>();
            }

            if (rigidbodyPoint == null)
            {
                rigidbodyPoint = GetComponent<Rigidbody>();
            }
        }
    }
}