using System.Collections.Generic;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Argument;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorSetting : SVSubInteractorEvent
    {
        [FoldoutGroup("Setting")] [BoxGroup("Setting/General")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        private SVPropertyComponent<string> target = new SVStringProperty();

        [FoldoutGroup("Setting")] [SerializeField] [Required] [RequiredListLength(1, 8)]
        protected List<Transform> interactionPoints = new();

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(2f, 5f)][OnValueChanged(nameof(OnInteractionAvailabilityRangeChanged), InvokeOnInitialize = true)]
        protected float interactionAvailabilityRange = 3f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0.5f, 3f)]
        protected float interactionRange = 1f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(1f, 180f)]
        protected float interactionAngle = 45f;
        
        public Transform CurrentInteractionPoint { get; protected set; }
        public bool CanInteract { get; protected set; }

        private string _cachedTargetLayer = "";

        public string TargetLayer
        {
            get
            {
                if (string.IsNullOrEmpty(_cachedTargetLayer))
                {
                    _cachedTargetLayer = target.GetValue(SVArgument.Create(gameObject));
                }

                return _cachedTargetLayer;
            }
        }

        private void OnInteractionAvailabilityRangeChanged()
        {
            if (sphereCollider != null)
            {
                sphereCollider.radius = interactionAvailabilityRange;
            }
        }
    }
}