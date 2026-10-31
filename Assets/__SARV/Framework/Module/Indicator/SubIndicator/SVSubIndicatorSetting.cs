using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Actor;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorSetting : SVSubIndicatorReference
    {
        [FoldoutGroup("Setting")] [BoxGroup("Setting/General")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel]
        private SVPropertyComponent<SVActor> actor = new SVActorProperty();

        [FoldoutGroup("Setting")] [BoxGroup("Setting/General")] [SerializeField] [PropertyRange(3f, 20f)] [OnValueChanged(nameof(OnDistanceDetectorRangeChanged), InvokeOnInitialize = true)]
        protected float distanceDetectorRange = 5f;

        [FoldoutGroup("Setting")] [BoxGroup("Setting/General")] [SerializeField] [PropertyRange(1, 10)]
        protected float uiRotationSpeed = 4f;

        [FoldoutGroup("Setting")] [BoxGroup("Setting/DistanceAnimation")] [SerializeField]
        protected Vector3 distanceUIScale = Vector3.one;

        [FoldoutGroup("Setting")] [BoxGroup("Setting/DistanceAnimation")] [SerializeField] [PropertyRange(0.1f, 2f)]
        protected float distanceUIScaleDuration = 0.25f;

        [FoldoutGroup("Setting")] [BoxGroup("Setting/DistanceAnimation")] [SerializeField]
        protected Ease distanceUIScaleEase = Ease.InOutBack;

        [FoldoutGroup("Setting")] [BoxGroup("Setting/FocusAnimation")] [SerializeField]
        protected Vector3 focusUIScale = Vector3.one;

        [FoldoutGroup("Setting")] [BoxGroup("Setting/FocusAnimation")] [SerializeField] [PropertyRange(0.1f, 2f)]
        protected float focusUIScaleDuration = 0.25f;

        [FoldoutGroup("Setting")] [BoxGroup("Setting/FocusAnimation")] [SerializeField]
        protected Ease focusUIScaleEase = Ease.InOutBack;

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

        private void OnDistanceDetectorRangeChanged()
        {
            if (sphereCollider != null)
            {
                sphereCollider.radius = distanceDetectorRange;
                sphereCollider.isTrigger = true;
            }
        }
    }
}