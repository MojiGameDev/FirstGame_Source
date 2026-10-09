using __SARV.Core.Access;
using __SARV.Core.Extension;
using __SARV.Play;
using UnityEngine;

namespace __SARV.Indicator.SubIndicator
{
    public abstract class SubSARVIndicatorShow : SubSARVIndicatorData
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
            SARVGame.Instance.Despawn(focusUIIdentifier);
            SARVGame.Instance.Despawn(distanceUIIdentifier);
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