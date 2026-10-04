using System;
using System.Threading.Tasks;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Argument;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Instruction
{
    [SVTitle("RunCondition")]
    [SVCategory(SVConstantCategory.Instruction.FRAMEWORK)]
    [SVDescription("Executes the specified condition")]
    [Serializable]
    public class SVFrameworkInstructionRunCondition : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Condition")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<SARVCondition> conditionProperty = new SVExternalPropertySARVCondition();

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinishProperty = new SVBoolPropertyManual();

        private bool IsConditionPropertyNull => conditionProperty == null || conditionProperty.Value == null;
        
        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(IsConditionPropertyNull ? "..." : conditionProperty)}";
        
        protected override async Task ExecuteInternal(SVArgument argument)
        {
            if (waitToFinishProperty.Value)
            {
                await conditionProperty.Value.RunCondition(argument);
                return;
            }
            _ = conditionProperty.Value.RunCondition(argument);
        }
    }
}