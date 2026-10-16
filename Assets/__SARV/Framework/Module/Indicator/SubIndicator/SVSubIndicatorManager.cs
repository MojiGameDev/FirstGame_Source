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
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            HandleShowDistanceUI();
            HandleShowFocusUI();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void HandleShowDistanceUI()
        {
            if (isTargetDetected && !canInteract)
            {
                HandleIndicatorMovement(distanceUI.transform);
            }
        }

        private void HandleShowFocusUI()
        {
            if (isTargetDetected && canInteract)
            {
                HandleIndicatorMovement(focusUI.transform);
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