using System;
using System.Threading.Tasks;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Actor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("SetCombatType")]
    [SVCategory(SVConstantCategory.Instruction.ACTOR)]
    [SVDescription("Sets the combat type of the specified actor")]
    [Serializable]
    public class SVActorInstructionSetCombatType : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();
        
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private SVCombatType combatType = SVCombatType.Melee;
        
        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Set {combatType.ToReadableString()} combat type to {actor}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var act = actor.GetValue(argument);
            act.SetCombatType(combatType);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}