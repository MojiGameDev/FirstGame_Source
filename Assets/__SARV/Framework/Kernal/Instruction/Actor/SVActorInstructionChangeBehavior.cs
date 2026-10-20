using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property.Actor;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction.Actor
{
    [SVTitle("ChangeBehavior")]
    [SVCategory(SVConstantCategory.Instruction.ACTOR)]
    [SVDescription("Change behavior of the Actor")]
    [Serializable]
    public class SVActorInstructionChangeBehavior : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SVActor> actor = new SVActorProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier behavior;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Change {actor} behavior to {(behavior == null ? "..." : behavior.SkipWords(2))}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            actor.GetValue(argument).ChangeBehaviorTo(behavior);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}