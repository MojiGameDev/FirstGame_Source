using __SARV.Framework.Module.Hitbox.Entity;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Reaction.Enum;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorCombat : SVSubActorEquipment
    {
        public SARVIdentifier AttackBehaviorIdentifier { get; protected set; }
        public SVHitResult CurrentHitResult { get; protected set; }
        
        public void SetAttackBehaviorIdentifier(SARVIdentifier identifier)
        {
            AttackBehaviorIdentifier = identifier;
        }

        public void SetHitResult(SVHitResult hitResult)
        {
            CurrentHitResult = hitResult;
        }
        
        public SVReactionDirection GetCurrentHitDirectionAsEnum()
        {
            // Reverse weapon travel direction.
            var incomingDirection = -CurrentHitResult.HitDirection;

            // Convert to actor-local direction.
            var localDirection = transform.InverseTransformDirection(incomingDirection);

            // Find the dominant axis.
            var absDirection = new Vector3(
                Mathf.Abs(localDirection.x),
                Mathf.Abs(localDirection.y),
                Mathf.Abs(localDirection.z)
            );

            if (absDirection.y > absDirection.x && absDirection.y > absDirection.z)
            {
                return localDirection.y > 0f ? SVReactionDirection.Top : SVReactionDirection.Bottom;
            }

            if (absDirection.z > absDirection.x)
            {
                return localDirection.z > 0f ? SVReactionDirection.Front : SVReactionDirection.Back;
            }

            return localDirection.x > 0f ? SVReactionDirection.Right : SVReactionDirection.Left;
        }
    }
}