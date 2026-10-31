using System;
using System.Threading.Tasks;
using ECM2;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior.Base
{
    [Serializable]
    public abstract class SVPlayerInteractBehavior : SVPlayerBehavior
    {
        [BoxGroup("Snap")] [SerializeField] [PropertyRange(0.1f, 2f)]
        protected float snapDuration = 0.3f;

        [BoxGroup("Snap")] [SerializeField] protected AnimationCurve snapCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        protected bool IsSnapping = false;
        protected float SnapTimer = 0f;
        protected Vector3 StartPosition;
        protected Quaternion StartRotation;
        protected Vector3 TargetPosition;
        protected Quaternion TargetRotation;
        protected Character.MovementMode PreviousMovementMode;
        protected Character.RotationMode PreviousRotationMode;

        public override async Task Enter()
        {
            await base.Enter();

            IsSnapping = true;
            SnapTimer = 0f;

            TargetPosition = Player.Character.CurrentInteractor.CurrentInteractionPoint.position;
            TargetRotation = Player.Character.CurrentInteractor.CurrentInteractionPoint.rotation;

            // Store start values
            StartPosition = Player.transform.position;
            StartRotation = Player.transform.rotation;

            PreviousMovementMode = Player.ECMCharacter.GetMovementMode();
            PreviousRotationMode = Player.ECMCharacter.GetRotationMode();

            Player.ECMCharacter.SetMovementMode(ECM2.Character.MovementMode.None);
            Player.ECMCharacter.SetRotationMode(ECM2.Character.RotationMode.None);
        }

        public override void Tick(float deltaTime)
        {
            if (IsSnapping)
            {
                HandleSnap(deltaTime);
            }
        }

        public override async Task Exit()
        {
            Player.ECMCharacter.SetMovementMode(PreviousMovementMode);
            Player.ECMCharacter.SetRotationMode(PreviousRotationMode);
            await base.Exit();
        }

        private void HandleSnap(float deltaTime)
        {
            SnapTimer += deltaTime;
            // Calculate progress (0 to 1)
            var t = Mathf.Clamp01(SnapTimer / snapDuration);
            var curveValue = snapCurve.Evaluate(t);

            // Interpolate position and rotation
            Player.transform.position = Vector3.Lerp(StartPosition, TargetPosition, curveValue);
            Player.transform.rotation = Quaternion.Slerp(StartRotation, TargetRotation, curveValue);

            // Check if snap is complete
            // When progress reaches 100%
            if (t >= 1f)
            {
                HandleCompleteSnap();
            }
        }

        private void HandleCompleteSnap()
        {
            // Ensure exact final position and rotation
            Player.transform.position = TargetPosition;
            Player.transform.rotation = TargetRotation;

            IsSnapping = false;
        }
    }
}