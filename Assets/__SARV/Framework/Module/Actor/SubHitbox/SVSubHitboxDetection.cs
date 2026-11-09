using System.Collections.Generic;
using __SARV.Common.Extension;
using __SARV.Framework.Module.Actor.Entity;
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

        public bool TryGetDetectedHit(out SVHitResult hitResult)
        {
            hitResult = default;

            if (!IsActive)
            {
                return false;
            }

            var currentPosition = GetWorldCenter();
            var currentRotation = transform.rotation;

            var movement = currentPosition - _lastPosition;
            var distance = movement.magnitude;

            var hitDirection = distance.HasValue()
                ? movement / distance
                : currentRotation * Vector3.forward;

            if (distance.HasValue())
            {
                if (Physics.BoxCast(
                        _lastPosition,
                        HalfExtents,
                        hitDirection,
                        out var hit,
                        _lastRotation,
                        distance,
                        targetLayer,
                        triggerMode))
                {
                    hitResult = ProcessHit(
                        hit.collider,
                        hit.point,
                        hitDirection
                    );

                    if (hitResult.IsValid)
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

                hitResult = ProcessHit(
                    targetCollider,
                    currentPosition,
                    hitDirection
                );

                if (hitResult.IsValid)
                {
                    UpdateLastTransform(currentPosition, currentRotation);
                    return true;
                }
            }

            UpdateLastTransform(currentPosition, currentRotation);
            return false;
        }

        private SVHitResult ProcessHit(Collider targetCollider, Vector3 hitPosition, Vector3 hitDirection)
        {
            var target = targetCollider.GetComponentInParent<SARVActor>();

            if (target == null || _hitTargets.Contains(target))
            {
                return default;
            }

            var closestHurtpoint = target.GetClosestHurtpoint(hitPosition);

            if (closestHurtpoint == null)
            {
                return default;
            }

            _hitTargets.Add(target);

            return new SVHitResult(target, closestHurtpoint, hitPosition, hitDirection);
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