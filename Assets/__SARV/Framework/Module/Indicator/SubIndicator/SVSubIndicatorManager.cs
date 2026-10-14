using __SARV.Common.Access;
using __SARV.Common.Extension;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorManager : SVSubIndicatorSetting
    {
        private Transform _focusUI;
        private Transform _distanceUI;

        protected override void Start()
        {
            base.Start();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            HandleIndicatorMovement(_focusUI);
            HandleIndicatorMovement(_distanceUI);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void HandleIndicatorMovement(Transform targetTransform)
        {
            var directionToFocusUI = SVAccessCamera.Transform.position - targetTransform.position;
            directionToFocusUI.y = 0f;

            if (directionToFocusUI.sqrMagnitude.HasValue())
            {
                var targetRotation = Quaternion.LookRotation(directionToFocusUI) * Quaternion.Euler(0f, 180f, 0f);
                targetTransform.rotation = Quaternion.Slerp(
                    targetTransform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}