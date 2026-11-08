using UnityEngine;

namespace __SARV.Framework.Module.Actor.Entity
{
    public readonly struct SVHitActorResult
    {
        public SARVActor Actor { get; }
        public SARVHurtpoint Hurtpoint { get; }
        public Vector3 HitPosition { get; }
        public Vector3 HitDirection { get; }

        public bool IsValid => Actor != null && Hurtpoint != null;

        public SVHitActorResult(SARVActor actor, SARVHurtpoint hurtpoint, Vector3 hitPosition, Vector3 hitDirection)
        {
            Actor = actor;
            Hurtpoint = hurtpoint;
            HitPosition = hitPosition;
            HitDirection = hitDirection;
        }
    }
}