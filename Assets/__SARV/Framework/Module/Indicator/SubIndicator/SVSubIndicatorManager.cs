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