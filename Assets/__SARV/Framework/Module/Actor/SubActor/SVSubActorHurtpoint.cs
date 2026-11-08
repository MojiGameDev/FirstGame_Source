using System;
using System.Collections;
using System.Collections.Generic;
using __SARV.Common.Extension;
using __SARV.Framework.Module.Actor.Entity;
using RootMotion.Dynamics;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorHurtpoint : SVSubActorData
    {
        [FoldoutGroup("Hurtpoint")] [SerializeField] [Required]
        private List<SARVHurtpoint> hurtpoints = new();

        [SerializeField] private float hitForce = 100f;

        [SerializeField, Range(0f, 1f)] private float hitPinWeight = 0.2f;

        [SerializeField] private float pinRecoveryDuration = 0.2f;
        
        [FoldoutGroup("Hurtpoint")]
        [Button]
        private void DetectHurtpoints()
        {
            hurtpoints.Clear();
            foreach (var hurtpoint in GetComponentsInChildren<SARVHurtpoint>(true))
            {
                hurtpoints.Add(hurtpoint);
            }
        }
        
        private readonly Dictionary<Muscle, Coroutine> recoveryCoroutines = new();
        private readonly Dictionary<Muscle, float> originalPinWeights = new();

        public void ApplyHit(SVHitActorResult hitActorResult)
        {
            if (hitActorResult.Hurtpoint.RigidbodyPoint == null)
            {
                Debug.LogError(hitActorResult.Hurtpoint.name);
                Debug.LogError("Hit Rigidbody is NULL.");
                return;
            }

            Debug.Log(
                $"Hit: {hitActorResult.Hurtpoint.RigidbodyPoint.name} | " +
                $"Kinematic: {hitActorResult.Hurtpoint.RigidbodyPoint.isKinematic} | " +
                $"Mass: {hitActorResult.Hurtpoint.RigidbodyPoint.mass} | " +
                $"Direction: {hitActorResult.HitDirection}"
            );

            if (hitActorResult.Hurtpoint.RigidbodyPoint.isKinematic)
            {
                Debug.LogError("Hit Rigidbody is Kinematic.");
                return;
            }

            if (!hitActorResult.IsValid) return;

            Muscle muscle = FindMuscle(hitActorResult.Hurtpoint.RigidbodyPoint);

            if (muscle == null) return;

            // Temporarily reduce this muscle's pin weight.
            Muscle.State state = muscle.state;

            if (!originalPinWeights.ContainsKey(muscle))
            {
                originalPinWeights.Add(muscle, state.pinWeightMlp);
            }

            state.pinWeightMlp = hitPinWeight;
            muscle.state = state;

            // Restart recovery if this muscle is hit again.
            if (recoveryCoroutines.TryGetValue(muscle, out Coroutine routine))
            {
                StopCoroutine(routine);
            }

            recoveryCoroutines[muscle] =
                StartCoroutine(RecoverPinWeight(muscle));

            // Apply physical impact.
            muscle.rigidbody.AddForceAtPosition(
                hitActorResult.HitDirection.normalized * hitForce,
                hitActorResult.HitPosition,
                ForceMode.Impulse
            );
            
            Debug.Log(GetHitDirection(hitActorResult));

            Debug.Log(
                $"Hit reaction: {hitActorResult.Hurtpoint.RigidbodyPoint.name}",
                this
            );
        }
        
        private SVHitDirection GetHitDirection(SVHitActorResult hit)
        {
            // Reverse weapon travel direction to get the incoming direction.
            Vector3 incomingDirection = -hit.HitDirection;

            // Convert world direction into actor-local direction.
            Vector3 localDirection = hit.Actor.transform
                .InverseTransformDirection(incomingDirection);

            // Ignore vertical direction.
            localDirection.y = 0f;
            localDirection.Normalize();

            if (Mathf.Abs(localDirection.z) > Mathf.Abs(localDirection.x))
            {
                return localDirection.z > 0f
                    ? SVHitDirection.Front
                    : SVHitDirection.Back;
            }

            return localDirection.x > 0f
                ? SVHitDirection.Right
                : SVHitDirection.Left;
        }

        private Muscle FindMuscle(Rigidbody target)
        {
            foreach (Muscle muscle in puppetMaster.muscles)
            {
                if (muscle.rigidbody == target)
                    return muscle;
            }

            return null;
        }

        private IEnumerator RecoverPinWeight(Muscle muscle)
        {
            yield return new WaitForSeconds(pinRecoveryDuration);

            Muscle.State state = muscle.state;

            if (originalPinWeights.TryGetValue(muscle, out float originalWeight))
            {
                state.pinWeightMlp = originalWeight;
                muscle.state = state;

                originalPinWeights.Remove(muscle);
            }

            recoveryCoroutines.Remove(muscle);
        }

        public SARVHurtpoint GetClosestHurtpoint(Vector3 hitPosition)
        {
            SARVHurtpoint closestHurtpoint = null;
            var closestDistance = float.MaxValue;

            foreach (var candidate in hurtpoints)
            {
                if (candidate == null)
                {
                    continue;
                }

                var distance = (candidate.transform.position - hitPosition).sqrMagnitude;

                if (distance >= closestDistance)
                {
                    continue;
                }

                closestDistance = distance;
                closestHurtpoint = candidate;
            }

            return closestHurtpoint;
        }
    }
    
    public enum SVHitDirection
    {
        Front,
        Back,
        Left,
        Right
    }
}