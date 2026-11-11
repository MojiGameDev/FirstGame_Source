using System.Collections;
using System.Collections.Generic;
using __SARV.Framework.Module.Hitbox.Entity;
using __SARV.Framework.Module.Hurtpoint;
using RootMotion.Dynamics;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorRagdoll : SVSubActorCombat
    {
        [SerializeField] private float hitForce = 100f;

        [SerializeField, Range(0f, 1f)] private float hitPinWeight = 0.2f;

        [SerializeField] private float pinRecoveryDuration = 0.2f;

        private readonly Dictionary<Muscle, Coroutine> recoveryCoroutines = new();
        private readonly Dictionary<Muscle, float> originalPinWeights = new();

        public void ApplyRagdollHit()
        {
            var targetHurtPoint = GetClosestHurtpoint(CurrentHitResult.HitPosition);
            if (targetHurtPoint.RigidbodyPoint == null)
            {
                //Debug.LogError("Hit Rigidbody is NULL.");
                return;
            }

            // Debug.Log(
            //     $"Hit: {hitResult.TargetHurtpoint.RigidbodyPoint.name} | " +
            //     $"Kinematic: {hitResult.TargetHurtpoint.RigidbodyPoint.isKinematic} | " +
            //     $"Mass: {hitResult.TargetHurtpoint.RigidbodyPoint.mass} | " +
            //     $"Direction: {hitResult.HitDirection}"
            // );

            if (targetHurtPoint.RigidbodyPoint.isKinematic)
            {
                //Debug.LogError("Hit Rigidbody is Kinematic.");
                return;
            }

            var muscle = FindMuscle(targetHurtPoint.RigidbodyPoint);

            if (muscle == null)
            {
                return;
            }

            // Temporarily reduce this muscle's pin weight.
            var muscleState = muscle.state;

            if (!originalPinWeights.ContainsKey(muscle))
            {
                originalPinWeights.Add(muscle, muscleState.pinWeightMlp);
            }

            muscleState.pinWeightMlp = hitPinWeight;
            muscle.state = muscleState;

            // Restart recovery if this muscle is hit again.
            if (recoveryCoroutines.TryGetValue(muscle, out Coroutine routine))
            {
                StopCoroutine(routine);
            }

            recoveryCoroutines[muscle] =
                StartCoroutine(RecoverPinWeight(muscle));

            // Apply physical impact.
            muscle.rigidbody.AddForce(
                CurrentHitResult.HitDirection.normalized * hitForce,
                ForceMode.Impulse
            );
            
            Debug.Log(
                $"Hit reaction: {targetHurtPoint.RigidbodyPoint.name}",
                this
            );
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

            var state = muscle.state;

            if (originalPinWeights.TryGetValue(muscle, out var originalWeight))
            {
                state.pinWeightMlp = originalWeight;
                muscle.state = state;
                originalPinWeights.Remove(muscle);
            }

            recoveryCoroutines.Remove(muscle);
        }
    }
}