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
        private SARVCondition condition;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinish = new SVBoolPropertyManual();

        private bool IsConditionNull => condition == null;
        
        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(IsConditionNull ? "..." : condition)}";
        
        protected override async Task ExecuteInternal(SVArgument argument)
        {
            if (waitToFinish.Value)
            {
                await condition.RunCondition(argument);
                return;
            }
            _ = condition.RunCondition(argument);
        }
    }
}