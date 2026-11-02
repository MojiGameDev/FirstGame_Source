using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Actor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Branch
{
    [SVTitle("IsCombatShooter")]
    [SVCategory(SVConstantCategory.Branch.ACTOR)]
    [SVDescription("Checks whether the specified actor's current combat type is Shooter")]
    [Serializable]
    public class SVActorBranchIsCombatShooter : SVBranchComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}{(Not ? "Is Not" : "Is")} Shooter Combat ({actor})";

        public override bool IsTrue(SVArgument argument)
        {
            var result = false;

            var act = actor.GetValue(argument);
            result = act.CurrentCombatType == SVCombatType.Shooter;

            return Not ? !result : result;
        }
    }
}