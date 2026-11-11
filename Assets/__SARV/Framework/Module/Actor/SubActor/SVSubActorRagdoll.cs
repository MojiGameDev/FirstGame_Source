using System.Collections;
using System.Collections.Generic;
using MEC;
using RootMotion.Dynamics;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorRagdoll : SVSubActorCombat
    {
        [SerializeField] private float hitForce = 100f;
        [SerializeField] private float hitPinWeight = 0.2f;
        [SerializeField] private float pinRecoveryDuration = 0.2f;

        private readonly Dictionary<Muscle, float> originalPinWeights = new();
        private readonly Dictionary<Muscle, CoroutineHandle> recoveryCoroutines = new();

        
        private void ApplyRagdollDead()
        {
            // Stop all pending pin-weight recoveries.
            foreach (var recovery in recoveryCoroutines.Values)
            {
                Timing.KillCoroutines(recovery);
            }

            recoveryCoroutines.Clear();

            // Restore temporary hit modifications.
            foreach (var pair in originalPinWeights)
            {
                pair.Key.state.pinWeightMlp = pair.Value;
            }

            originalPinWeights.Clear();
            
            PuppetMaster.Kill();
        }

        public void ApplyRagdollHit()
        {
            var hurtpoint = GetClosestHurtpoint(CurrentHitResult.HitPosition);

            if (hurtpoint == null)
                return;

            var hitRigidbody = hurtpoint.RigidbodyPoint;

            if (hitRigidbody == null)
                return;

            var muscle = FindMuscle(hitRigidbody);

            if (muscle == null)
                return;

            ApplyMuscleHit(muscle);
        }

        private Muscle FindMuscle(Rigidbody target)
        {
            foreach (var muscle in puppetMaster.muscles)
            {
                if (muscle.rigidbody == target)
                    return muscle;
            }

            return null;
        }

        private void ApplyMuscleHit(Muscle muscle)
        {
            // Preserve the original value only on the first hit.
            if (!originalPinWeights.ContainsKey(muscle))
                originalPinWeights.Add(muscle, muscle.state.pinWeightMlp);

            // Restart recovery for this muscle.
            if (recoveryCoroutines.TryGetValue(muscle, out var recovery))
            {
                Timing.KillCoroutines(recovery);
                recoveryCoroutines.Remove(muscle);
            }

            muscle.state.pinWeightMlp = hitPinWeight;

            muscle.rigidbody.AddForceAtPosition(
                CurrentHitResult.HitDirection.normalized * hitForce,
                CurrentHitResult.HitPosition,
                ForceMode.Impulse
            );

            if (pinRecoveryDuration <= 0f)
            {
                RestorePinWeight(muscle);
                return;
            }

            recoveryCoroutines.Add(
                muscle,
                Timing.RunCoroutine(RecoverPinWeight(muscle))
            );
        }

        private IEnumerator<float> RecoverPinWeight(Muscle muscle)
        {
            yield return Timing.WaitForSeconds(pinRecoveryDuration);

            RestorePinWeight(muscle);
        }

        private void RestorePinWeight(Muscle muscle)
        {
            if (originalPinWeights.TryGetValue(muscle, out var originalWeight))
            {
                muscle.state.pinWeightMlp = originalWeight;
                originalPinWeights.Remove(muscle);
            }

            recoveryCoroutines.Remove(muscle);
        }
    }
}