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
            var closestPoint = FindClosestInteractionPoint();

            if (closestPoint == null)
            {
                CanInteract = false;
                return;
            }

            var isInteractionPointChanged = closestPoint != CurrentInteractionPoint;

            if (!isInteractionPointChanged)
            {
                return;
            }

            CanInteract = true;
            CurrentInteractionPoint = closestPoint;

            OnInteractionAvailabilityChanged?.Invoke(CanInteract, CurrentInteractionPoint.position, CurrentInteractionPoint.rotation);
        }

        private Transform FindClosestInteractionPoint()
        {
            if (interactionPoints == null || !interactionPoints.Any())
            {
                return null;
            }

            Transform closestPoint = null;
            var closestDistanceSqr = float.PositiveInfinity;

            var characterForward = transform.forward;
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

                var offset = point.position - transform.position;
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