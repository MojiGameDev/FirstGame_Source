using System.Collections.Generic;
using __SARV.Common.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubHitbox
{
    public abstract class SVSubHitboxDetection : SVSubHitboxSetting
    {
        [FoldoutGroup("Detection")] [SerializeField]
        private LayerMask targetLayer;

        [FoldoutGroup("Detection")] [SerializeField]
        private QueryTriggerInteraction triggerMode = QueryTriggerInteraction.Collide;

        public bool IsActive { get; private set; }

        private readonly Collider[] _overlapResults = new Collider[32];
        private readonly HashSet<SARVActor> _hitTargets = new();

        private Vector3 _lastPosition;
        private Quaternion _lastRotation;

        private Vector3 HalfExtents => hitboxSize * 0.5f;

        public void Activate()
        {
            _hitTargets.Clear();

            _lastPosition = GetWorldCenter();
            _lastRotation = transform.rotation;

            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
            _hitTargets.Clear();
        }

        public bool TryGetDetectedHit(out SARVHurtpoint hurtpoint)
        {
            hurtpoint = null;

            if (!IsActive)
            {
                return false;
            }

            var currentPosition = GetWorldCenter();
            var currentRotation = transform.rotation;

            var direction = currentPosition - _lastPosition;
            var distance = direction.magnitude;

            if (distance.HasValue())
            {
                if (Physics.BoxCast(
                        _lastPosition,
                        HalfExtents,
                        direction.normalized,
                        out var hit,
                        _lastRotation,
                        distance,
                        targetLayer,
                        triggerMode))
                {
                    hurtpoint = ProcessHit(hit.collider, hit.point);

                    if (hurtpoint != null)
                    {
                        UpdateLastTransform(currentPosition, currentRotation);
                        return true;
                    }
                }
            }

            var count = Physics.OverlapBoxNonAlloc(
                currentPosition,
                HalfExtents,
                _overlapResults,
                currentRotation,
                targetLayer,
                triggerMode
            );

            for (var i = 0; i < count; i++)
            {
                var targetCollider = _overlapResults[i];

                if (targetCollider == null)
                {
                    continue;
                }

                hurtpoint = ProcessHit(targetCollider, currentPosition);

                if (hurtpoint != null)
                {
                    UpdateLastTransform(currentPosition, currentRotation);
                    return true;
                }
            }

            UpdateLastTransform(currentPosition, currentRotation);
            return false;
        }

        private SARVHurtpoint ProcessHit(Collider targetCollider, Vector3 hitPosition)
        {
            var target = targetCollider.GetComponentInParent<SARVActor>();

            if (target == null || _hitTargets.Contains(target))
            {
                return null;
            }

            var closestHurtpoint = target.GetClosestHurtpoint(hitPosition);

            if (closestHurtpoint == null)
            {
                return null;
            }

            _hitTargets.Add(target);

            return closestHurtpoint;
        }

        private void UpdateLastTransform(Vector3 position, Quaternion rotation)
        {
            _lastPosition = position;
            _lastRotation = rotation;
        }

        protected Vector3 GetWorldCenter()
        {
            return transform.TransformPoint(hitboxOffset);
        }
    }
}