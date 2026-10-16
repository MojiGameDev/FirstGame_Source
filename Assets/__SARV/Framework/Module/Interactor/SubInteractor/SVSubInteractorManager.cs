using System.Linq;
using __SARV.Common.Extension;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorManager : SVSubInteractorDetection
    {
        private bool _initialized;
        protected Transform _closestPoint;

        protected override void Update()
        {
            base.Update();

            if (isTargetDetected)
            {
                HandleInteractionAvailability();
            }
        }

        private void HandleInteractionAvailability()
        {
            _closestPoint = FindClosestInteractionPoint();
            if (_closestPoint == null)
            {
                if (CanInteract)
                {
                    OnInteractionAvailabilityChanged?.Invoke(false);
                }

                CanInteract = false;
                CurrentInteractionPoint = null;
                return;
            }

            var isInteractionPointChanged = _closestPoint != CurrentInteractionPoint;

            if (!isInteractionPointChanged)
            {
                return;
            }

            CurrentInteractionPoint = _closestPoint;

            if (!CanInteract)
            {
                CanInteract = true;
                OnInteractionAvailabilityChanged?.Invoke(CanInteract);
            }
        }

        private Transform FindClosestInteractionPoint()
        {
            if (!interactionPoints.Any() || Target == null)
            {
                return null;
            }

            Transform closestPoint = null;
            var closestDistanceSqr = float.PositiveInfinity;

            var characterForward = Target.transform.forward;
            characterForward.y = 0f;

            if (!characterForward.sqrMagnitude.HasValue())
            {
                return null;
            }

            characterForward.Normalize();

            var rangeSqr = interactionRange * interactionRange;

            foreach (var point in interactionPoints)
            {
                if (point == null)
                {
                    continue;
                }

                var offset = point.position - Target.transform.position;
                offset.y = 0f;

                var distanceSqr = offset.sqrMagnitude;

                if (distanceSqr > rangeSqr || distanceSqr >= closestDistanceSqr)
                {
                    continue;
                }

                var requiredForward = point.forward;
                requiredForward.y = 0f;

                if (!requiredForward.sqrMagnitude.HasValue())
                {
                    continue;
                }

                requiredForward.Normalize();

                if (Vector3.Angle(characterForward, requiredForward) > interactionAngle)
                {
                    continue;
                }

                closestDistanceSqr = distanceSqr;
                closestPoint = point;
            }

            return closestPoint;
        }
    }
}