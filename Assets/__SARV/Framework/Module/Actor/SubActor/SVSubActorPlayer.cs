using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorPlayer : SVSubActorTrait
    {
        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)] [ShowIf(nameof(IsActorPlayer))]
        private float changeSpeedDuration = 0.2f;

        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)] [ShowIf(nameof(IsActorPlayer))]
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

        public void UpdatePlayerSpeed(float newSpeed, float newRotationRate)
        {
            KillTween();
            _changeSpeedTween = DOTween.To(() => ecmCharacter.maxWalkSpeed, x => ecmCharacter.maxWalkSpeed = x, newSpeed, changeSpeedDuration)
                .SetEase(Ease.Linear);
            _changeRotationRateTween = DOTween.To(() => ecmCharacter.rotationRate, x => ecmCharacter.rotationRate = x, newRotationRate, changeRotationRateDuration)
                .SetEase(Ease.Linear);
        }

        public void SetPlayerMovementDirection(Vector3 direction)
        {
            ecmCharacter.SetMovementDirection(direction);
        }

        public void StopPlayerMovement()
        {
            SetPlayerMovementDirection(Vector3.zero);
        }

        public void EnablePlayerRootMotion()
        {
            ecmCharacter.useRootMotion = true;
        }

        public void DisablePlayerRootMotion()
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