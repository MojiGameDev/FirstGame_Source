using __SARV.Framework.Module.Hitbox.Entity;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Melee;
using __SARV.Framework.Module.Reaction.Enum;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorCombat : SVSubActorEquipment
    {
        public SARVIdentifier AttackBehaviorIdentifier { get; private set; }
        public SVHitResult CurrentHitResult { get; private set; }
        public SARVMeleeAttack CurrentMeleeAttack { get; private set; }
        
        public void SetAttackBehaviorIdentifier(SARVIdentifier identifier)
        {
            AttackBehaviorIdentifier = identifier;
        }

        public void SetCurrentHitResult(SVHitResult hitResult)
        {
            CurrentHitResult = hitResult;
        }

        public void SetCurrentMeleeAttack(SARVMeleeAttack meleeAttack)
        {
            CurrentMeleeAttack = meleeAttack;
        }
        
        public SVReactionDirection GetCurrentHitDirectionAsEnum()
        {
            // Reverse weapon travel direction.
            var incomingDirection = -CurrentHitResult.HitDirection;

            // Convert to actor-local direction.
            var localDirection = transform.InverseTransformDirection(incomingDirection);

            // Compare horizontal axes only.
            if (Mathf.Abs(localDirection.z) > Mathf.Abs(localDirection.x))
            {
                return localDirection.z > 0f
                    ? SVReactionDirection.Front
                    : SVReactionDirection.Back;
            }

            return localDirection.x > 0f
                ? SVReactionDirection.Right
                : SVReactionDirection.Left;
        }
    }
}