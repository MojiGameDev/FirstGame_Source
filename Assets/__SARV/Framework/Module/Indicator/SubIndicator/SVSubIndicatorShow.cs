using __SARV.Common.Access;
using __SARV.Common.Extension;
using __SARV.SceneControl.Game;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorShow : SVSubIndicatorData
    {
        private Transform _focusUI;
        private Transform _distanceUI;

        protected override void Start()
        {
            base.Start();
            _focusUI = SARVGame.Instance.SpawnInPool(focusUIIdentifier, focusUIPosition.Value);
            _distanceUI = SARVGame.Instance.SpawnInPool(distanceUIIdentifier, distanceUIPosition.Value);
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
            if (SARVGame.IsAvailable)
            {
                SARVGame.Instance.Despawn(focusUIIdentifier);
                SARVGame.Instance.Despawn(distanceUIIdentifier);
            }
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
                    rotationSpeed.Value * Time.deltaTime
                );
            }
        }
    }
}