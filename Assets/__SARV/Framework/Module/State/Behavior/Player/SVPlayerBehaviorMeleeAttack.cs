using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.Animancer.Parameter.Type;
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
        [BoxGroup("Event")] [SerializeField] [HideLabel] [Required]
        private StringAsset meleeAttackEvent;

        public override async Task Enter()
        {
            await base.Enter();
            Player.EnablePlayerRootMotion();
            Player.AnimancerComponent.Events.AddTo<SVMeleeAttackParameterType>(meleeAttackEvent, HandleMeleeEventHandler);
            HandleMatchedMeleeAttack();
        }

        public override void Tick(float deltaTime)
        {
        }

        public override async Task Exit()
        {
            Player.DisablePlayerRootMotion();
            Player.AnimancerComponent.Events.Remove(meleeAttackEvent);
            await base.Exit();
        }

        private void HandleMatchedMeleeAttack()
        {
            var comboNode = GetMatchedCombo();
            if (comboNode == null)
            {
                //Finished
            }
            else
            {
                Player.PlayAnimancer(comboNode.Attack.Identifier);
            }
        }

        private SVComboNode GetMatchedCombo()
        {
            var meleeWeapon = Player.CurrentMeleeWeapon;
            foreach (var combo in meleeWeapon.MeleeCombo.Combos)
            {
                if (combo.OnCanPerformBranch.IsBranchesPassed(Player.Argument))
                {
                    return combo;
                }
            }

            return null;
        }

        private void HandleMeleeEventHandler(SVMeleeAttackParameterType parameter)
        {
            Debug.Log(parameter.AttackPhase);
        }
    }
}