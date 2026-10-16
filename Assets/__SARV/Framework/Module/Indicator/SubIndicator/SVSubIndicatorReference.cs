using __SARV.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Interactor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected GameObject focusUI;

        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected GameObject distanceUI;

        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected SphereCollider sphereCollider;

        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected SARVInteractor interactor;

        [OnInspectorInit]
        private void InitialReference()
        {
            if (sphereCollider == null)
            {
                sphereCollider = GetComponent<SphereCollider>();
            }
        }
    }
}