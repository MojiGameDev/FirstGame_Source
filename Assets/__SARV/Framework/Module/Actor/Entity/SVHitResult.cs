using UnityEngine;

namespace __SARV.Framework.Module.Actor.Entity
{
    public readonly struct SVHitResult
    {
        public SARVActor TargetActor { get; }
        public SARVHurtpoint TargetHurtpoint { get; }
        public Vector3 HitPosition { get; }
        public Vector3 HitDirection { get; }

        public bool IsValid => TargetActor != null && TargetHurtpoint != null;

        public SVHitResult(SARVActor targetActor, SARVHurtpoint targetHurtpoint, Vector3 hitPosition, Vector3 hitDirection)
        {
            TargetActor = targetActor;
            TargetHurtpoint = targetHurtpoint;
            HitPosition = hitPosition;
            HitDirection = hitDirection;
        }
    }
}