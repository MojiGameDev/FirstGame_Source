using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("RunCondition")]
    [SVCategory(SVConstantCategory.Instruction.KERNAL)]
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
        
        protected override async Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            if (waitToFinish.GetValue(argument))
            {
                await condition.RunCondition(argument);
            }
            {
                _ = condition.RunCondition(argument);
            }
            return await SVInstructionResult.DEFAULT_RESULT;
        }
    }
}