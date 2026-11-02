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
    [SVTitle("EquipShield")]
    [SVCategory(SVConstantCategory.Instruction.MELEE)]
    [SVDescription("Equips the specified melee shield to Actor")]
    [Serializable]
    public class SVMeleeInstructionEquipShield : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVMeleeShield meleeShield;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Equip {(meleeShield == null ? "..." : meleeShield.name)} to {actor}";

        protected override async Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var act = actor.GetValue(argument);
            await act.EquipMeleeShield(meleeShield);
            return await SVInstructionResult.DEFAULT_RESULT;
        }
    }
}