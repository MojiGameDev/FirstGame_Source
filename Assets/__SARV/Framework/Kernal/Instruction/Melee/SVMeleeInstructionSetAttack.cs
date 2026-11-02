using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Melee;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction.Melee
{
    [SVTitle("SetAttack")]
    [SVCategory(SVConstantCategory.Instruction.MELEE)]
    [SVDescription("Set the specified melee attack to Actor")]
    [Serializable]
    public class SVMeleeInstructionSetAttack : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVMeleeAttack meleeAttack;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Set {(meleeAttack == null ? "..." : meleeAttack.name)} to {actor}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var act = actor.GetValue(argument);
            act.SetMeleeAttack(meleeAttack);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}