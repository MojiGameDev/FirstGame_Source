using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property.Actor;
using __SARV.Framework.Module.Interactor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction.Actor
{
    [SVTitle("SetInteractor")]
    [SVCategory(SVConstantCategory.Instruction.ACTOR)]
    [SVDescription("Set an interactor to the actor")]
    [Serializable]
    public class SVActorInstructionSetInteractor : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SVActor> actor = new SVActorProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVInteractor interactor;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Set {(interactor == null ? "..." : interactor.gameObject.name)} to {actor} ";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            actor.GetValue(argument).SetInteractor(interactor);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}