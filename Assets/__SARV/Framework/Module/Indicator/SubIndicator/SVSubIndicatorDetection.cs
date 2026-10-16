using __SARV.Common.Access;
using __SARV.Common.Extension;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorDetection : SVSubIndicatorSetting
    {
        [FoldoutGroup("Detection")] [SerializeField] [ReadOnly]
        protected bool isTargetDetected;

        [FoldoutGroup("Detection")] [SerializeField] [ReadOnly]
        protected bool canInteract;

        private Tween _distanceUIScaleTween;
        private Tween _focusUIScaleTween;

        protected override void Start()
        {
            base.Start();
            interactor.OnInteractionAvailabilityChanged.AddListener(OnInteractionAvailabilityChangedHandler);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.IsLayerDetected(TargetLayer))
            {
                HandleActiveAndScaleDistanceUI();
                isTargetDetected = true;
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.IsLayerDetected(TargetLayer))
            {
                HandleInactiveAndScaleDistanceUI();
                isTargetDetected = false;
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _distanceUIScaleTween?.Kill();
            _focusUIScaleTween?.Kill();
            interactor.OnInteractionAvailabilityChanged.RemoveListener(OnInteractionAvailabilityChangedHandler);
        }

        private void OnInteractionAvailabilityChangedHandler(bool canDoInteract)
        {
            canInteract = canDoInteract;
            if (canInteract)
            {
                HandleInactiveAndScaleDistanceUI();
                HandleActiveAndScaleFocusUI();
            }
            else
            {
                HandleInactiveAndScaleFocusUI();
                if (isTargetDetected)
                {
                    HandleActiveAndScaleDistanceUI();
                }
            }
        }

        private void HandleActiveAndScaleDistanceUI()
        {
            if (canInteract)
            {
                return;
            }

            HandleSnapRotationToTarget(distanceUI.transform);
            _distanceUIScaleTween?.Kill();
            distanceUI.Active();
            distanceUI.LocalScaleToZero();

            _distanceUIScaleTween = distanceUI.transform
                .DOScale(distanceUIScale, distanceUIScaleDuration)
                .SetEase(distanceUIScaleEase);
        }

        private void HandleActiveAndScaleFocusUI()
        {
            HandleSnapRotationToTarget(focusUI.transform);
            _focusUIScaleTween?.Kill();
            focusUI.Active();
            focusUI.LocalScaleToZero();

            _focusUIScaleTween = focusUI.transform
                .DOScale(focusUIScale, focusUIScaleDuration)
                .SetEase(focusUIScaleEase);
        }

        protected void HandleInactiveAndScaleDistanceUI()
        {
            _distanceUIScaleTween?.Kill();

            _distanceUIScaleTween = distanceUI.transform
                .DOScale(Vector3.zero, distanceUIScaleDuration)
                .SetEase(distanceUIScaleEase)
                .OnComplete(() =>
                {
                    distanceUI.Inactive();
                    distanceUI.LocalScaleToZero();
                });
        }

        protected void HandleInactiveAndScaleFocusUI()
        {
            _focusUIScaleTween?.Kill();

            _focusUIScaleTween = focusUI.transform
                .DOScale(Vector3.zero, focusUIScaleDuration)
                .SetEase(focusUIScaleEase)
                .OnComplete(() =>
                {
                    focusUI.Inactive();
                    focusUI.LocalScaleToZero();
                });
        }

        private void HandleSnapRotationToTarget(Transform targetTransform)
        {
            if (TryToGetTargetRotation(targetTransform, out var targetRotation))
            {
                targetTransform.rotation = targetRotation;
            }
        }

        protected bool TryToGetTargetRotation(Transform targetTransform, out Quaternion targetRotation)
        {
            targetRotation = Quaternion.identity;
            var directionToCamera = SVAccessCamera.Transform.position - targetTransform.position;
            if (directionToCamera.sqrMagnitude.HasValue())
            {
                targetRotation = Quaternion.LookRotation(directionToCamera) * Quaternion.Euler(0f, 180f, 0f);
                return true;
            }

            return false;
        }
    }
}