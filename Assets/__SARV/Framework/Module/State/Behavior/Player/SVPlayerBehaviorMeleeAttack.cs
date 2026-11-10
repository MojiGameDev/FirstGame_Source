using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.Animancer.Enum;
using __SARV.Framework.Integration.Animancer.Parameter.Type;
using __SARV.Framework.Module.Hitbox;
using __SARV.Framework.Module.Hitbox.Entity;
using __SARV.Framework.Module.Melee.Entity;
using __SARV.Framework.Module.State.Behavior.Base;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior
{
    [SVTitle("MeleeAttack")]
    [SVCategory(SVConstantCategory.Behavior.PLAYER)]
    [SVDescription("Handles the player's melee attack behavior")]
    [Serializable]
    public class SVPlayerBehaviorMeleeAttack : SVPlayerBehavior
    {
        [BoxGroup("Animancer")] [SerializeField] [Required]
        private StringAsset meleeAttackEvent;

        private SVComboNode _currentComboNode;
        private SARVHitbox _currentHitbox;
        private bool _goToNextComboAttack = false;
        private bool _canCheckNextComboAttack = false;
        private bool _isAttackDone;

        public override async Task Enter()
        {
            await base.Enter();
            await Actor.CurrentMeleeWeapon.MeleeCombo.ExecuteOnStart(Actor.Argument);
            _currentComboNode = null;
            _currentHitbox = null;
            _goToNextComboAttack = false;
            _canCheckNextComboAttack = false;
            _isAttackDone = false;
            Actor.EnablePlayerRootMotion();
            Actor.AnimancerComponent.Events.AddTo<SVMeleeAttackParameterType>(meleeAttackEvent, HandleMeleeEventHandler);
            HandleMatchedCombo();
            HandlePlayMatchedMeleeAttack();
        }

        public override void Tick(float deltaTime)
        {
            if (_isAttackDone)
            {
                return;
            }

            if (_canCheckNextComboAttack && !_goToNextComboAttack && Actor.InputAttack)
            {
                _goToNextComboAttack = true;
            }

            if (_currentHitbox != null && _currentHitbox.IsActive)
            {
                if (_currentHitbox.TryGetHitInfo(out var targetActor, out var hitPosition, out var hitDirection))
                {
                    Debug.Log("Hit");
                    var hitResult = new SVHitResult(targetActor, hitPosition, hitDirection, _currentComboNode.Attack.Power, _currentComboNode.Attack.Force);
                    targetActor.SetHitResult(hitResult);
                    _ = _currentComboNode.Attack.ExecuteOnHit(Actor.Argument);
                    _ = targetActor.CurrentMeleeShield.ExecuteOnDamage(targetActor.Argument);
                }
            }
        }

        public override async Task Exit()
        {
            Actor.DisablePlayerRootMotion();
            Actor.AnimancerComponent.Events.Remove(meleeAttackEvent);
            await base.Exit();
        }

        private void HandlePlayMatchedMeleeAttack()
        {
            Actor.PlayAnimancer(_currentComboNode.Attack.TransitionAlias, restart: true);
        }

        private void HandleHitbox(SVComboNode comboNode)
        {
            var boneTransform = comboNode.Attack.Bone.GetTransform(Actor.AnimancerComponent.Animator);
            _currentHitbox = boneTransform.GetComponentInChildren<SARVHitbox>();
        }

        private void HandleMatchedCombo()
        {
            var rootCombos = Actor.CurrentMeleeWeapon.MeleeCombo.Combos;
            var combos = _currentComboNode?.Combos ?? rootCombos;

            if (TryGetComboAttack(combos, out var currentCombo))
            {
                _currentComboNode = currentCombo;
                return;
            }

            _currentComboNode = null;

            if (TryGetComboAttack(rootCombos, out currentCombo))
            {
                _currentComboNode = currentCombo;
            }
        }

        private bool TryGetComboAttack(IReadOnlyList<SVComboNode> combos, out SVComboNode currentCombo)
        {
            currentCombo = null;

            foreach (var combo in combos)
            {
                if (combo.CanPerform(Actor.Argument))
                {
                    currentCombo = combo;
                    HandleHitbox(currentCombo);
                    _currentHitbox.Deactivate();
                    return true;
                }
            }

            return false;
        }

        private void HandleMeleeEventHandler(SVMeleeAttackParameterType parameter)
        {
            if (_isAttackDone)
            {
                return;
            }

            switch (parameter.AttackPhase)
            {
                case SVMeleeAttackPhase.Start:
                    _canCheckNextComboAttack = true;
                    break;
                case SVMeleeAttackPhase.Next:
                    HandleNextAttack();
                    _canCheckNextComboAttack = false;
                    break;
                case SVMeleeAttackPhase.End:
                    _isAttackDone = true;
                    _ = Actor.CurrentMeleeWeapon.MeleeCombo.ExecuteOnEnd(Actor.Argument);
                    break;
                case SVMeleeAttackPhase.EnableHitbox:
                    _currentHitbox.Activate();
                    break;
                case SVMeleeAttackPhase.DisableHitbox:
                    _currentHitbox.Deactivate();
                    break;
            }
        }

        private void HandleNextAttack()
        {
            if (_goToNextComboAttack)
            {
                _goToNextComboAttack = false;
                HandleMatchedCombo();
                HandlePlayMatchedMeleeAttack();
            }
        }
    }
}