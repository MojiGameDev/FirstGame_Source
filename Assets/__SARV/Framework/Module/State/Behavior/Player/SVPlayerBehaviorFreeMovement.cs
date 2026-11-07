using System;
using System.Threading.Tasks;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.State.Behavior.Base;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior
{
    [SVTitle("FreeMovement")]
    [SVCategory(SVConstantCategory.Behavior.PLAYER)]
    [SVDescription("Allows the player to freely move through the game world")]
    [Serializable]
    public class SVPlayerBehaviorFreeMovement : SVPlayerBehavior
    {
        [BoxGroup("Animancer")] [SerializeField] [Required]
        private StringAsset transitionAlias;

        [BoxGroup("Animancer")] [SerializeField] [Required]
        private StringAsset movementSpeedParameter;

        [BoxGroup("Speed")] [SerializeField] [PropertyRange(1, 10)]
        private float runSpeed = 8f;

        [BoxGroup("Speed")] [SerializeField] private float runRotationRate = 540f;

        [BoxGroup("Speed")] [SerializeField] [PropertyRange(1, 20)]
        private float sprintSpeed = 11f;

        [BoxGroup("Speed")] [SerializeField] private float sprintRotationRate = 700f;

        private bool _isMovementSpeedParameterChanged;

        private SmoothedFloatParameter _smoothedFloatParameterMovementSpeed;

        private const int PARAMETER_MOVEMENT_SPEED_IDLE = 0;
        private const int PARAMETER_MOVEMENT_SPEED_RUN = 1;
        private const int PARAMETER_MOVEMENT_SPEED_SPRINT = 2;
        private const float PARAMETER_MOVEMENT_SPEED_SMOOTH_TIME = 0.15f;

        public override async Task Enter()
        {
            await base.Enter();
            _smoothedFloatParameterMovementSpeed = new SmoothedFloatParameter(
                Actor.AnimancerComponent,
                movementSpeedParameter,
                PARAMETER_MOVEMENT_SPEED_SMOOTH_TIME);
            Actor.PlayAnimancer(transitionAlias);
            Actor.HandlePlayerSpeed(runSpeed, runRotationRate);
            _smoothedFloatParameterMovementSpeed.TargetValue = PARAMETER_MOVEMENT_SPEED_IDLE;
            Actor.SetMovementSpeed(SVActorSpeed.Idle);
        }

        public override void Tick(float deltaTime)
        {
            Actor.SetPlayerMovementDirection(Actor.InputMovementDirection);
            HandleMovementSpeedParameter();
            HandleCharacterSpeed();
        }

        public override async Task Exit()
        {
            Actor.HandlePlayerSpeed(runSpeed, runRotationRate);
            _smoothedFloatParameterMovementSpeed.Dispose();
            await base.Exit();
        }

        private void HandleCharacterSpeed()
        {
            if (!_isMovementSpeedParameterChanged)
            {
                return;
            }

            if (Actor.CurrentSpeed == SVActorSpeed.Sprint)
            {
                Actor.HandlePlayerSpeed(sprintSpeed, sprintRotationRate);
            }
            else
            {
                Actor.HandlePlayerSpeed(runSpeed, runRotationRate);
            }
        }

        private void HandleMovementSpeedParameter()
        {
            SVActorSpeed newMovementSpeed;
            if (Actor.InputMovementDirection.HasValue())
            {
                newMovementSpeed = Actor.InputSprint ? SVActorSpeed.Sprint : SVActorSpeed.Run;
            }
            else
            {
                newMovementSpeed = SVActorSpeed.Idle;
            }

            if (Actor.CurrentSpeed == newMovementSpeed)
            {
                _isMovementSpeedParameterChanged = false;
                return;
            }

            _isMovementSpeedParameterChanged = true;
            Actor.SetMovementSpeed(newMovementSpeed);

            _smoothedFloatParameterMovementSpeed.TargetValue = GetMovementSpeed();
        }

        private int GetMovementSpeed()
        {
            var speed = 0;
            switch (Actor.CurrentSpeed)
            {
                case SVActorSpeed.Idle:
                    speed = PARAMETER_MOVEMENT_SPEED_IDLE;
                    break;
                case SVActorSpeed.Run:
                    speed = PARAMETER_MOVEMENT_SPEED_RUN;
                    break;
                case SVActorSpeed.Sprint:
                    speed = PARAMETER_MOVEMENT_SPEED_SPRINT;
                    break;
            }

            return speed;
        }
    }
}