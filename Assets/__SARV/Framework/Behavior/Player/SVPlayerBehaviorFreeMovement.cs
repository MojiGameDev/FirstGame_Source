using System;
using __SARV.Core.Attributes;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using __SARV.Core.Extension;
using __SARV.Framework.Behavior.Base;
using __SARV.Identifier;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Behavior
{
    [SVTitle("FreeMovement")]
    [SVCategory(SVConstantCategory.Behavior.PLAYER)]
    [SVDescription("Allows the player to freely move through the game world")]
    [Serializable]
    public class SVPlayerBehaviorFreeMovement : SVPlayerBehavior
    {
        [BoxGroup("Speed")] [SerializeField] [PropertyRange(1, 10)]
        private float runSpeed = 8f;

        [BoxGroup("Speed")] [SerializeField] private float runRotationRate = 540f;

        [BoxGroup("Speed")] [SerializeField] [PropertyRange(1, 20)]
        private float sprintSpeed = 11f;

        [BoxGroup("Speed")] [SerializeField] private float sprintRotationRate = 700f;

        [BoxGroup("Parameter")] [SerializeField] [Required]
        private SARVIdentifier parameterMovementSpeed;

        private bool _isMovementSpeedParameterChanged;

        private SmoothedFloatParameter _smoothedFloatParameterMovementSpeed;

        private const int PARAMETER_MOVEMENT_SPEED_IDLE = 0;
        private const int PARAMETER_MOVEMENT_SPEED_RUN = 1;
        private const int PARAMETER_MOVEMENT_SPEED_SPRINT = 2;
        private const float PARAMETER_MOVEMENT_SPEED_SMOOTH_TIME = 0.15f;

        public override void Enter()
        {
            _smoothedFloatParameterMovementSpeed = new SmoothedFloatParameter(
                Player.AnimancerComponent,
                Player.SharedAnimancer.RuntimeAlias[parameterMovementSpeed],
                PARAMETER_MOVEMENT_SPEED_SMOOTH_TIME);
            Player.SharedAnimancer.Play(Identifier);
            Player.UpdateSpeed(runSpeed, runRotationRate);
            _smoothedFloatParameterMovementSpeed.TargetValue = PARAMETER_MOVEMENT_SPEED_IDLE;
        }

        public override void Tick(float deltaTime)
        {
            Player.SetMovementDirection(Player.InputMovementDirection);
            HandleMovementSpeedParameter();
            HandleCharacterSpeed();
        }

        public override void Exit()
        {
            Player.UpdateSpeed(runSpeed, runRotationRate);
            _smoothedFloatParameterMovementSpeed.Dispose();
        }

        private void HandleCharacterSpeed()
        {
            if (!_isMovementSpeedParameterChanged)
            {
                return;
            }

            if (Player.MovementSpeed == SVCharacterMovementSpeed.Sprint)
            {
                Player.UpdateSpeed(sprintSpeed, sprintRotationRate);
            }
            else
            {
                Player.UpdateSpeed(runSpeed, runRotationRate);
            }
        }

        private void HandleMovementSpeedParameter()
        {
            SVCharacterMovementSpeed newMovementSpeed;
            if (Player.InputMovementDirection.HasValue())
            {
                newMovementSpeed = Player.InputSprint ? SVCharacterMovementSpeed.Sprint : SVCharacterMovementSpeed.Run;
            }
            else
            {
                newMovementSpeed = SVCharacterMovementSpeed.Idle;
            }

            if (Player.MovementSpeed == newMovementSpeed)
            {
                _isMovementSpeedParameterChanged = false;
                return;
            }

            _isMovementSpeedParameterChanged = true;
            Player.SetMovementSpeed(newMovementSpeed);

            _smoothedFloatParameterMovementSpeed.TargetValue = GetMovementSpeed();
        }

        private int GetMovementSpeed()
        {
            var movementSpeed = 0;
            switch (Player.MovementSpeed)
            {
                case SVCharacterMovementSpeed.Idle:
                    movementSpeed = PARAMETER_MOVEMENT_SPEED_IDLE;
                    break;
                case SVCharacterMovementSpeed.Run:
                    movementSpeed = PARAMETER_MOVEMENT_SPEED_RUN;
                    break;
                case SVCharacterMovementSpeed.Sprint:
                    movementSpeed = PARAMETER_MOVEMENT_SPEED_SPRINT;
                    break;
            }

            return movementSpeed;
        }
    }
}