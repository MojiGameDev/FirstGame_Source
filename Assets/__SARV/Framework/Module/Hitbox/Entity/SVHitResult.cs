using __SARV.Framework.Module.Reaction.Enum;
using UnityEngine;

namespace __SARV.Framework.Module.Hitbox.Entity
{
    public readonly struct SVHitResult
    {
        public Vector3 HitPosition { get; }
        public Vector3 HitDirection { get; }
        public SVReactionPower Power { get; }
        public float Force { get; }

        public SVHitResult(Vector3 hitPosition, Vector3 hitDirection, SVReactionPower power, float force)
        {
            HitPosition = hitPosition;
            HitDirection = hitDirection;
            Power = power;
            Force = force;
        }
    }
}