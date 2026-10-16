using __SARV.Common.Extension;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorGizmos : SVSubInteractorSetting
    {
        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool showGizmos = true;

        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool gizmosOnSelect = true;

        [FoldoutGroup("Gizmos")] [SerializeField] [PropertyRange(0.1f, 0.5)]
        private float gizmoRadius = 0.15f;
        
        private bool _initialized;

        protected override void Update()
        {
            base.Update();

            var closestPoint = FindClosestInteractionPoint();

            var canInteract = closestPoint != null;

            var changed = !_initialized || canInteract != CanInteract || closestPoint != CurrentInteractionPoint;

            if (!changed)
            {
                return;
            }

            _initialized = true;
            CanInteract = canInteract;
            CurrentInteractionPoint = closestPoint;

            var position = canInteract ? closestPoint.position : Vector3.zero;
            var rotation = canInteract ? closestPoint.rotation : Quaternion.identity;

            OnInteractionAvailabilityChanged?.Invoke(CanInteract, position, rotation);
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            if (!gizmosOnSelect)
            {
                HandleShowGizmos();
            }
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            HandleShowGizmos();
        }

        private Transform FindClosestInteractionPoint()
        {
            if (target == null || interactionPoints == null)
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

        private void HandleShowGizmos()
        {
            if (!showGizmos || interactionPoints == null)
            {
                return;
            }

            foreach (var point in interactionPoints)
            {
                if (point == null)
                {
                    continue;
                }

                var isCurrent = point == CurrentInteractionPoint;

                HandleDrawInteractionPoint(point, isCurrent);
            }
        }

        private void HandleDrawInteractionPoint(Transform point, bool isCurrent)
        {
            var origin = point.position;
            var forward = point.forward;

            forward.y = 0f;

            if (!forward.sqrMagnitude.HasValue())
            {
                return;
            }

            forward.Normalize();

            var halfAngle = interactionAngle;

            var left = Quaternion.AngleAxis(-halfAngle, Vector3.up) * forward;

            var right = Quaternion.AngleAxis(halfAngle, Vector3.up) * forward;

            Gizmos.color = isCurrent ? Color.green : Color.yellow;
            Gizmos.DrawSphere(origin, gizmoRadius);

            Gizmos.color = isCurrent ? Color.green : Color.cyan;
            Gizmos.DrawRay(origin, forward * interactionRange);
            Gizmos.DrawRay(origin, left * interactionRange);
            Gizmos.DrawRay(origin, right * interactionRange);

#if UNITY_EDITOR
            Handles.color = isCurrent
                ? new Color(0f, 1f, 0f, 0.2f)
                : new Color(0f, 1f, 1f, 0.12f);

            Handles.DrawSolidArc(
                origin,
                Vector3.up,
                left,
                halfAngle * 2f,
                interactionRange);
#endif
        }
    }
}