using System.Threading.Tasks;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Interactor;
using __SARV.Framework.Module.Melee;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerCharacter : SVSubPlayerTrait
    {
        [FoldoutGroup("Character")] [SerializeField] [HideLabel]
        private SVCharacter character;

        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)]
        private float changeSpeedDuration = 0.2f;

        [FoldoutGroup("Character")] [BoxGroup("Character/Duration")] [SerializeField] [PropertyRange(0.1f, 2f)]
        private float changeRotationRateDuration = 0.2f;

        private Tween _changeSpeedTween;
        private Tween _changeRotationRateTween;
        public SVCharacter Character => character;

        protected override void Awake()
        {
            base.Awake();
            Character.HandleAwake();
        }

        protected override void Start()
        {
            base.Start();
            Character.HandleStart();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Character.HandleOnDestroy();
            KillTween();
        }

        public override void ChangeBehaviorTo(SARVIdentifier stateIdentifier)
        {
            StateMachine.ChangeBehaviorTo(stateIdentifier);
        }

        public override void SetInteractor(SARVInteractor interactor)
        {
            Character.SetInteractor(interactor);
        }

        public override void AttachProp(GameObject prop, SVBone bone, Vector3 position, Vector3 rotation)
        {
            Character.AttachProp(AnimancerComponent.Animator, prop, bone, position, rotation);
        }

        public override void Equip(SARVMelee melee)
        {
            Character.Equip(this, melee);
        }

        public override void Unequip()
        {
            Character.Unequip(this);
        }

        public override SARVMelee GetCurrentMelee()
        {
            return Character.CurrentMelee;
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