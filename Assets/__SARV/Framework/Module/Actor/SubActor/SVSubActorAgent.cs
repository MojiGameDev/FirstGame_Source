using System;
using DG.Tweening;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorAgent : SVSubActorPlayer
    {
        [FoldoutGroup("Agent")] [BoxGroup("Agent/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)] [ShowIf(nameof(IsActorAgent))]
        private float changeMovementSpeedDuration = 1f;

        [FoldoutGroup("Agent")] [BoxGroup("Agent/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)] [ShowIf(nameof(IsActorAgent))]
        private float changeRotationSpeedDuration = 1f;

        [FoldoutGroup("Agent")] [BoxGroup("Agent/Astar")] [SerializeField] [PropertyRange(0.2f, 10f)] [OnCollectionChanged(nameof(HandleAgentDefaultEndReachedDistance))] [ShowIf(nameof(IsActorAgent))]
        protected float defaultEndReachedDistance = 0.2f;

        private static readonly NearestNodeConstraint NEAREST_WALKABLE_CONSTRAINT = NearestNodeConstraint.Walkable;

        private Tween _changeSpeedTween;
        private Tween _changeRotationRateTween;

        protected override void OnDestroy()
        {
            base.OnDestroy();
            KillTween();
        }

        public void HandleAgentDestination(Vector3 target)
        {
            AIDestinationSetter.target.position = target;
        }

        public void HandleAgentDestination(Transform target)
        {
            AIDestinationSetter.target.position = target.position;
        }

        public NNInfo GetAgentNearestPoint(Vector3 target)
        {
            var nearest = AstarPath.active.GetNearest(target, NEAREST_WALKABLE_CONSTRAINT);
            return nearest;
        }

        public NNInfo GetAgentNearestPoint(Transform target)
        {
            return GetAgentNearestPoint(target.position);
        }

        public void HandleAgentDefaultEndReachedDistance()
        {
            HandleAgentEndReachedDistance(defaultEndReachedDistance);
        }

        public void HandleAgentEndReachedDistance(float endReachedDistance)
        {
            aiPath.slowdownDistance = endReachedDistance;
            aiPath.endReachedDistance = endReachedDistance;
        }

        public bool HasAgentReachedTarget()
        {
            if (!aiPath.hasPath || aiPath.pathPending)
            {
                return false;
            }

            if (aiPath.reachedDestination)
            {
                return true;
            }

            var distance = Vector3.Distance(
                Position,
                aiDestinationSetter.target.position
            );

            var hasReachedTarget = distance <= aiPath.endReachedDistance;

            return hasReachedTarget;
        }

        public void HandleAgentTransformBasedMovement()
        {
            aiPath.simulateMovement = true;
            aiPath.updatePosition = true;
            aiPath.updateRotation = true;
            aiPath.enableRotation = true;
        }

        public void HandleAgentTransformBasedMovementWithNoRotation()
        {
            aiPath.simulateMovement = true;
            aiPath.updatePosition = true;
            aiPath.updateRotation = false;
            aiPath.enableRotation = false;
        }

        public void HandleAgentRootMotionMovement()
        {
            aiPath.simulateMovement = false;
            aiPath.updatePosition = true;
            aiPath.updateRotation = false;
            aiPath.enableRotation = false;
        }

        public void HandleAgentStopMovement()
        {
            aiPath.simulateMovement = false;
            aiPath.updatePosition = false;
        }

        public void HandleAgentStopRotation()
        {
            aiPath.updateRotation = false;
            aiPath.enableRotation = false;
        }

        public void HandleStopAgentMovementRotation()
        {
            HandleAgentStopMovement();
            HandleAgentStopRotation();
        }

        public void HandleAgentSpeed(float movementSpeed, float rotationSpeed)
        {
            KillTween();
            _changeSpeedTween = DOTween.To(() => aiPath.maxSpeed, x => aiPath.maxSpeed = x, movementSpeed, changeMovementSpeedDuration)
                .SetEase(Ease.Linear);
            _changeRotationRateTween = DOTween
                .To(() => aiPath.rotationSpeed, x => aiPath.rotationSpeed = x, rotationSpeed, changeRotationSpeedDuration)
                .SetEase(Ease.Linear);
        }

        private void KillTween()
        {
            _changeSpeedTween?.Kill();
            _changeRotationRateTween?.Kill();
        }
    }
}