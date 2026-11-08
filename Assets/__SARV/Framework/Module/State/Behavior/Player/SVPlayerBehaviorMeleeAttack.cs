using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.Animancer.Enum;
using __SARV.Framework.Integration.Animancer.Parameter.Type;
using __SARV.Framework.Module.Actor;
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

        private SVComboNode _currentCombo;
        private SARVHitbox _currentHitbox;

        public override async Task Enter()
        {
            await base.Enter();
            _currentCombo = null;
            _currentHitbox = null;
            Actor.EnablePlayerRootMotion();
            Actor.AnimancerComponent.Events.AddTo<SVMeleeAttackParameterType>(meleeAttackEvent, HandleMeleeEventHandler);
            HandleMatchedCombo();
            HandlePlayMatchedMeleeAttack();
        }

        public override void Tick(float deltaTime)
        {
            if (_currentHitbox != null && _currentHitbox.IsActive)
            {
                if (_currentHitbox.TryGetDetectedHit(out var hitActorResult))
                {
                    hitActorResult.Actor.ApplyHit(hitActorResult);
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
            Actor.PlayAnimancer(_currentCombo.Attack.TransitionAlias);
        }

        private void HandleHitbox(SVComboNode comboNode)
        {
            var boneTransform = comboNode.Attack.Bone.GetTransform(Actor.AnimancerComponent.Animator);
            _currentHitbox = boneTransform.GetComponentInChildren<SARVHitbox>();
        }

        private void HandleMatchedCombo()
        {
            var rootCombos = Actor.CurrentMeleeWeapon.MeleeCombo.Combos;
            var combos = _currentCombo?.Combos ?? rootCombos;

            if (TryGetComboAttack(combos, out var currentCombo))
            {
                _currentCombo = currentCombo;
                return;
            }

            _currentCombo = null;

            if (TryGetComboAttack(rootCombos, out currentCombo))
            {
                _currentCombo = currentCombo;
            }
        }

        private bool TryGetComboAttack(IReadOnlyList<SVComboNode> combos, out SVComboNode currentCombo)
        {
            currentCombo = null;

            foreach (var combo in combos)
            {
                if (combo.OnCanPerformBranch.IsBranchesPassed(Actor.Argument))
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
            switch (parameter.AttackPhase)
            {
                case SVMeleeAttackPhase.Start:
                    break;
                case SVMeleeAttackPhase.Next:
                    break;
                case SVMeleeAttackPhase.End:
                    Debug.Log("End");
                    Actor.StateMachine.ToFirst();
                    break;
                case SVMeleeAttackPhase.EnableHitbox:
                    _currentHitbox.Activate();
                    break;
                case SVMeleeAttackPhase.DisableHitbox:
                    _currentHitbox.Deactivate();
                    break;
            }
        }
    }
}