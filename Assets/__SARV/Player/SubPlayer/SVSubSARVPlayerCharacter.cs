using __SARV.Core.Enum;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerCharacter : SVSubSARVPlayerTrait
    {
        [FoldoutGroup("Character")] [BoxGroup("Character/Data")] [SerializeField] [ReadOnly]
        private SVCharacterMovementSpeed movementSpeed = SVCharacterMovementSpeed.NotMoving;

        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)]
        private float changeSpeedDuration = 0.2f;

        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)]
        private float changeRotationRateDuration = 0.2f;

        private Tween _changeSpeedTween;
        private Tween _changeRotationRateTween;

        public SVCharacterMovementSpeed MovementSpeed => movementSpeed;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            KillTween();
        }

        public void UpdateSpeed(float newSpeed, float newRotationRate)
        {
            KillTween();
            _changeSpeedTween = DOTween.To(() => Character.maxWalkSpeed, x => Character.maxWalkSpeed = x, newSpeed, changeSpeedDuration)
                .SetEase(Ease.Linear);
            _changeRotationRateTween = DOTween.To(() => Character.rotationRate, x => Character.rotationRate = x, newRotationRate, changeRotationRateDuration)
                .SetEase(Ease.Linear);
        }

        private void KillTween()
        {
            _changeSpeedTween?.Kill();
            _changeRotationRateTween?.Kill();
        }

        public void SetMovementDirection(Vector3 direction)
        {
            Character.SetMovementDirection(direction);
        }

        public void StopMovement()
        {
            SetMovementDirection(Vector3.zero);
        }

        public void EnableRootMotion()
        {
            Character.useRootMotion = true;
        }

        public void DisableRootMotion()
        {
            Character.useRootMotion = false;
        }

        public void SetMovementSpeed(SVCharacterMovementSpeed speed)
        {
            movementSpeed = speed;
        }
    }
}