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

namespace __SARV.Framework.Kernal.Instruction.Melee
{
    [SVTitle("UnequipWeapon")]
    [SVCategory(SVConstantCategory.Instruction.MELEE)]
    [SVDescription("Unequips the actor's current melee weapon")]
    [Serializable]
    public class SVMeleeInstructionUnequipWeapon : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SVActor> actor = new SVActorProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Unequips current melee weapon of {actor}";

        protected override async Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var act = actor.GetValue(argument);
            await act.UnequipMeleeWeapon();
            return await SVInstructionResult.DEFAULT_RESULT;
        }
    }
}