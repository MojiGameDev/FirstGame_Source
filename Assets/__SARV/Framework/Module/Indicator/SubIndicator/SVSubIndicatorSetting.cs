using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorSetting : SVSubIndicatorReference
    {
        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(3f, 20f)] [OnValueChanged(nameof(OnDistanceDetectorRangeChanged), InvokeOnInitialize = true)]
        private float distanceDetectorRange = 5f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(1, 10)]
        protected float uiRotationSpeed = 4f;

        private void OnDistanceDetectorRangeChanged()
        {
            if (sphereCollider != null)
            {
                sphereCollider.radius = distanceDetectorRange;
            }
        }
    }
}