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
        private SARVCondition sarvCondition;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinishProperty = new SVBoolPropertyManual();

        private bool IsConditionPropertyNull => sarvCondition == null;
        
        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(IsConditionPropertyNull ? "..." : sarvCondition)}";
        
        protected override async Task ExecuteInternal(SVArgument argument)
        {
            if (waitToFinishProperty.Value)
            {
                await sarvCondition.RunCondition(argument);
                return;
            }
            _ = sarvCondition.RunCondition(argument);
        }
    }
}