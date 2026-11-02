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
        private readonly HashSet<SARVHurtpoint> _hurtTargets = new();
        private Vector3 _lastPosition;
        private Quaternion _lastRotation;
        private Vector3 HalfExtents => hitboxSize * 0.5f;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            DetectHits();
        }

        public void Activate()
        {
            _hurtTargets.Clear();

            _lastPosition = GetWorldCenter();
            _lastRotation = transform.rotation;

            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
            _hurtTargets.Clear();
        }

        private void DetectHits()
        {
            if (!IsActive)
            {
                return;
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
                    ProcessHit(hit.collider, hit.point, hit.normal);
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

                var hitPosition = targetCollider.ClosestPoint(currentPosition);
                var hitNormal = (hitPosition - currentPosition).normalized;

                ProcessHit(targetCollider, hitPosition, hitNormal);
            }

            _lastPosition = currentPosition;
            _lastRotation = currentRotation;
        }

        private void ProcessHit(Collider targetCollider, Vector3 hitPosition, Vector3 hitNormal)
        {
            var hurtpoint = targetCollider.GetComponentInParent<SARVHurtpoint>();

            if (hurtpoint == null || !_hurtTargets.Add(hurtpoint))
            {
                return;
            }

            //OnHit?.Invoke(hitpoint, hitPosition, hitNormal);
        }

        protected Vector3 GetWorldCenter()
        {
            return transform.TransformPoint(hitboxOffset);
        }
    }
}