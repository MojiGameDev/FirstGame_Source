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
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("GoToAttackBehavior")]
    [SVCategory(SVConstantCategory.Instruction.ACTOR)]
    [SVDescription("Change behavior of the Actor to attack")]
    [Serializable]
    public class SVActorInstructionGoToAttackBehavior : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();
        
        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Change {actor} behavior to attack";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var act = actor.GetValue(argument);
            act.StateMachine.ChangeBehaviorTo(act.AttackBehaviorIdentifier);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}