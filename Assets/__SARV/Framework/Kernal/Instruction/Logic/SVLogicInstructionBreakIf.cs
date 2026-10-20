using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction.Logic
{
    [SVTitle("BreakIf")]
    [SVCategory(SVConstantCategory.Instruction.LOGIC)]
    [SVDescription("Breaks instruction execution if the condition is true")]
    [Serializable]
    public class SVLogicInstructionBreakIf : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private SVBranch branch;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Break instruction execution if condition result is True";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var isBranchesPassed = branch.IsBranchesPassed(argument);

            if (isBranchesPassed)
            {
                return SVInstructionResult.BREAK_EXECUTION_RESULT;
            }

            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}