using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Enum;
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
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private SVConditionType conditionType = SVConditionType.FirstIf;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("Branches")] [LabelText("$BranchesLabels")]
        private List<SVBranch> branches = new();

        private string BranchesLabels => $"{branches.Count} Conditions";
        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}{(conditionType == SVConditionType.FirstIf ? "Break instruction execution if any condition is true" : "Break instruction execution if all conditions are true")}";
       
        protected override async Task ExecuteInternal(SVArgument argument)
        {
            var isInstructionExecute = false;
            
            foreach (var branch in branches)
            {
                var isBranchesPassed = branch.IsBranchesPassed(argument);
                if (isBranchesPassed && !branch.Not)
                {
                    isInstructionExecute = true;
                    await branch.Instruction.ExecuteInstructions(argument);
                }
                else if (!isBranchesPassed && branch.Not)
                {
                    isInstructionExecute = true;
                    await branch.Instruction.ExecuteInstructions(argument);
                }

                if (conditionType == SVConditionType.FirstIf && isInstructionExecute)
                {
                    BreakExecution();
                    return;
                }

                if (conditionType == SVConditionType.AllIf && !isInstructionExecute)
                {
                    BreakExecution();
                    return;
                }
            }
        }
    }
}