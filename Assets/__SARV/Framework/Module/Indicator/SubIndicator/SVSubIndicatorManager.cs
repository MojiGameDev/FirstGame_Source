using __SARV.Common.Access;
using __SARV.Common.Extension;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorManager : SVSubIndicatorDebug
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            HandleIndicatorMovement(focusUI.transform);
            HandleIndicatorMovement(distanceUI.transform);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void HandleIndicatorMovement(Transform targetTransform)
        {
            var directionToCamera = SVAccessCamera.Transform.position - targetTransform.position;

            if (directionToCamera.sqrMagnitude.HasValue())
            {
                var targetRotation = Quaternion.LookRotation(directionToCamera) * Quaternion.Euler(0f, 180f, 0f);
                targetTransform.rotation = Quaternion.Slerp(
                    targetTransform.rotation,
                    targetRotation,
                    uiRotationSpeed * Time.deltaTime
                );
            }
        }
    }
}