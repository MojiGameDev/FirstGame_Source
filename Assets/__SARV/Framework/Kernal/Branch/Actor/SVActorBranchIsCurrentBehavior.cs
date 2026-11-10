using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Branch
{
    [SVTitle("IsCurrentBehavior")]
    [SVCategory(SVConstantCategory.Branch.ACTOR)]
    [SVDescription("Checks whether the actor is currently in the specified behavior state")]
    [Serializable]
    public class SVActorBranchIsCurrentBehavior : SVBranchComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();
        
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier behavior;

        public override bool IsTrue(SVArgument argument)
        {
            var act = actor.GetValue(argument);

            var result = act.StateMachine.IsCurrentStateBehavior(behavior);
            
            return Not ? !result : result;
        }
    }
}