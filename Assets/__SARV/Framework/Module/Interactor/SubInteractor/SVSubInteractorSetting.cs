using System.Collections.Generic;
using System.Linq;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Kernal.Property.Actor;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorSetting : SVSubInteractorEvent
    {
        [FoldoutGroup("Setting")] [BoxGroup("Setting/General")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        private SVPropertyComponent<SVActor> target = new SVActorProperty();

        [FoldoutGroup("Setting")] [SerializeField] [Required] [RequiredListLength(1, 20)]
        protected List<Transform> interactionPoints = new();

        [FoldoutGroup("Setting")]
        [Button]
        [EnableIf(nameof(HasInteractionPoints))]
        protected void PlacePointsOnGround()
        {
            foreach (var point in interactionPoints)
            {
                if (point == null)
                {
                    continue;
                }

                var origin = point.position + Vector3.up * 1000f;

                if (Physics.Raycast(
                        origin,
                        Vector3.down,
                        out var hit,
                        2000f,
                        Physics.DefaultRaycastLayers,
                        QueryTriggerInteraction.Ignore))
                {
                    Undo.RecordObject(point, "Place Path Point On Ground");
                    point.position = hit.point;
                }
            }
        }

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(2f, 5f)] [OnValueChanged(nameof(OnInteractionAvailabilityRangeChanged), InvokeOnInitialize = true)]
        protected float interactionAvailabilityRange = 3f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0.5f, 3f)]
        protected float interactionRange = 1f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(1f, 180f)]
        protected float interactionAngle = 45f;

        public Transform CurrentInteractionPoint { get; protected set; }
        public bool CanInteract { get; protected set; }
        private bool HasInteractionPoints => interactionPoints.Any();

        private SVActor _cachedActor;

        public SVActor Actor
        {
            get
            {
                if (_cachedActor == null)
                {
                    _cachedActor = target.GetValue(SVArgument.Create(gameObject));
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