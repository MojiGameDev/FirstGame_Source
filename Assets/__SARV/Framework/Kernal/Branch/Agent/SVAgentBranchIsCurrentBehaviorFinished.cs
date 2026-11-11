using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Actor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Branch.Agent
{
    [SVTitle("IsCurrentBehaviorFinished")]
    [SVCategory(SVConstantCategory.Branch.AGENT)]
    [SVDescription("Checks whether the actor's current behavior has finished executing")]
    [Serializable]
    public class SVAgentBranchIsCurrentBehaviorFinished : SVBranchComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}{(Not ? "Is not" : "Is")} {(actor == null ? "..." : actor)}'s current behavior finished";
       
        public override bool IsTrue(SVArgument argument)
        {
            var act = actor.GetValue(argument);

            var result = act.StateMachine.IsCurrentAgentBehaviorFinished();

            return Not ? !result : result;
        }
    }
}