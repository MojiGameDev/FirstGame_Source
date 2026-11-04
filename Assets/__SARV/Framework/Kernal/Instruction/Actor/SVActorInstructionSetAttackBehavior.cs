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
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("SetAttackBehavior")]
    [SVCategory(SVConstantCategory.Instruction.ACTOR)]
    [SVDescription("Set attack behavior of the Actor")]
    [Serializable]
    public class SVActorInstructionSetAttackBehavior : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();
        
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier behavior;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Change {actor} attack behavior to {(behavior == null ? "..." : behavior.SkipWords(2))}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var act = actor.GetValue(argument);
            act.SetAttackBehaviorIdentifier(behavior);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}