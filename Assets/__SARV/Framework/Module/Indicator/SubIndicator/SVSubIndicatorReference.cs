using __SARV.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        protected SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected GameObject focusUI;

        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected GameObject distanceUI;

        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected SphereCollider sphereCollider;

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