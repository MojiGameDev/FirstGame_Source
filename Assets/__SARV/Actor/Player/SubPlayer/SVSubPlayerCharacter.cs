using __SARV.Framework.Module.Identifier;
using DG.Tweening;
using ECM2;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerCharacter : SVSubPlayerTrait
    {
        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)]
        private float changeSpeedDuration = 0.2f;

        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)]
        private float changeRotationRateDuration = 0.2f;

        private Tween _changeSpeedTween;
        private Tween _changeRotationRateTween;

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
            _changeSpeedTween = DOTween.To(() => ecmCharacter.maxWalkSpeed, x => ecmCharacter.maxWalkSpeed = x, newSpeed, changeSpeedDuration)
                .SetEase(Ease.Linear);
            _changeRotationRateTween = DOTween.To(() => ecmCharacter.rotationRate, x => ecmCharacter.rotationRate = x, newRotationRate, changeRotationRateDuration)
                .SetEase(Ease.Linear);
        }

        public void SetMovementDirection(Vector3 direction)
        {
            ecmCharacter.SetMovementDirection(direction);
        }

        public void StopMovement()
        {
            SetMovementDirection(Vector3.zero);
        }

        public void EnableRootMotion()
        {
            ecmCharacter.useRootMotion = true;
        }

        public void DisableRootMotion()
        {
            ecmCharacter.useRootMotion = false;
        }

        private void KillTween()
        {
            _changeSpeedTween?.Kill();
            _changeRotationRateTween?.Kill();
        }
    }
}