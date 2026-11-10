using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Hurtpoint;
using __SARV.Framework.Module.Reaction.Enum;
using UnityEngine;

namespace __SARV.Framework.Module.Hitbox.Entity
{
    public readonly struct SVHitResult
    {
        public SARVActor TargetActor { get; }
        public Vector3 HitPosition { get; }
        public Vector3 HitDirection { get; }
        public SVReactionPower Power { get; }
        public float Force { get; }

        public SVHitResult(SARVActor targetActor, Vector3 hitPosition, Vector3 hitDirection, SVReactionPower power, float force)
        {
            TargetActor = targetActor;
            HitPosition = hitPosition;
            HitDirection = hitDirection;
            Power = power;
            Force = force;
        }

        public SVReactionDirection GetDirectionAsEnum()
        {
            // Reverse weapon travel direction.
            var incomingDirection = -HitDirection;

            // Convert to actor-local direction.
            var localDirection = TargetActor.transform.InverseTransformDirection(incomingDirection);

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