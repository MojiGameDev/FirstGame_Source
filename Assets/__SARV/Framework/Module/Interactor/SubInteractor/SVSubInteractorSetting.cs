using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorSetting : SVSubInteractorEvent
    {
        [FoldoutGroup("Setting")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        private SVPropertyComponent<SVActor> actor = new SVActorProperty();

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(2f, 5f)] [OnValueChanged(nameof(OnInteractionAvailabilityRangeChanged), InvokeOnInitialize = true)]
        protected float interactionAvailabilityRange = 3f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0.5f, 3f)]
        protected float interactionRange = 1f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(1f, 180f)]
        protected float interactionAngle = 45f;

        public Transform CurrentInteractionPoint { get; protected set; }
        public bool CanInteract { get; protected set; }

        private SVActor _cachedActor;

        public SVActor Actor
        {
            get
            {
                if (_cachedActor == null)
                {
                    _cachedActor = actor.GetValue(SVArgument.Create(gameObject));
                }

                return _cachedActor;
            }
        }

        private void OnInteractionAvailabilityRangeChanged()
        {
            if (sphereCollider != null)
            {
                sphereCollider.radius = interactionAvailabilityRange;
                sphereCollider.isTrigger = true;
            }
        }
    }
}