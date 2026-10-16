using __SARV.Common.Access;
using __SARV.Common.Extension;
using DG.Tweening;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorManager : SVSubIndicatorDetection
    {
        protected override void Start()
        {
            base.Start();
            distanceUI.Inactive();
            focusUI.Inactive();
            interactor.OnInteractionAvailabilityChanged.AddListener(OnInteractionAvailabilityChangedHandler);
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            HandleShowDistanceUI();
        }

        private void HandleShowDistanceUI()
        {
            if (isTargetDetected)
            {
                HandleIndicatorMovement(distanceUI.transform);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            interactor.OnInteractionAvailabilityChanged.RemoveListener(OnInteractionAvailabilityChangedHandler);
        }

        private void OnInteractionAvailabilityChangedHandler(bool canDoInteract, Vector3 targetPosition, Quaternion targetRotation)
        {
            canInteract = canDoInteract;
            if (canInteract)
            {
                HandleInactiveAndScaleDistanceUI();
            }
        }

        private void HandleIndicatorMovement(Transform targetTransform)
        {
            if (TryToGetTargetRotation(targetTransform, out var targetRotation))
            {
                targetTransform.rotation = Quaternion.Slerp(
                    targetTransform.rotation,
                    targetRotation,
                    uiRotationSpeed * Time.deltaTime
                );
            }
        }
    }
}