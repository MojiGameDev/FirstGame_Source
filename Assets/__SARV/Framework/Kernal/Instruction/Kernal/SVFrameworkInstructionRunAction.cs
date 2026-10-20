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
    [SVTitle("RunAction")]
    [SVCategory(SVConstantCategory.Instruction.KERNAL)]
    [SVDescription("Executes the specified action")]
    [Serializable]
    public class SVFrameworkInstructionRunAction : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Action")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SARVAction action;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinish = new SVBoolPropertyManual();

        private bool IsActionNull => action == null || action == null;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(IsActionNull ? "..." : action)}";

        protected override async Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            if (waitToFinish.GetValue(argument))
            {
                await action.RunAction(argument);
            }
            else
            {
                _ = action.RunAction(argument);
            }
            
            return await SVInstructionResult.DEFAULT_RESULT;
        }
    }
}