using System.Linq;
using __SARV.Common.Extension;
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
                if (CanInteract)
                {
                    OnInteractionAvailabilityChanged?.Invoke(false);
                }

                CanInteract = false;
                CurrentInteractionPoint = null;
                return;
            }

            var isInteractionPointChanged = closestPoint != CurrentInteractionPoint;

            if (!isInteractionPointChanged)
            {
                return;
            }

            CurrentInteractionPoint = closestPoint;

            if (!CanInteract)
            {
                CanInteract = true;
                OnInteractionAvailabilityChanged?.Invoke(CanInteract);
            }
        }

        private Transform FindClosestInteractionPoint()
        {
            if (!interactionPoints.Any() || Actor == null)
            {
                return null;
            }

            Transform closestPoint = null;
            var closestDistanceSqr = float.PositiveInfinity;

            var actorForward = Actor.Forward;
            actorForward.y = 0f;

            if (!actorForward.sqrMagnitude.HasValue())
            {
                return null;
            }

            actorForward.Normalize();

            var rangeSqr = interactionRange * interactionRange;

            foreach (var interactionPoint in interactionPoints)
            {
                var offset = interactionPoint.position - Actor.Position;
                offset.y = 0f;

                var distanceSqr = offset.sqrMagnitude;

                if (distanceSqr > rangeSqr || distanceSqr >= closestDistanceSqr)
                {
                    continue;
                }

                var requiredForward = interactionPoint.forward;
                requiredForward.y = 0f;

                if (!requiredForward.sqrMagnitude.HasValue())
                {
                    continue;
                }

                requiredForward.Normalize();

                if (Vector3.Angle(actorForward, requiredForward) > interactionAngle)
                {
                    continue;
                }

                closestDistanceSqr = distanceSqr;
                closestPoint = interactionPoint;
            }

            return closestPoint;
        }
    }
}