using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Enum;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal
{
    public class SARVCondition : SVKernal
    {
        [SerializeField] private SVConditionType conditionType = SVConditionType.FirstIf;

        [SerializeField] private bool hasElse;

        [SerializeField] [Title("Branches")] [LabelText("$BranchesLabels")]
        private List<SVInstructionBranch> instructionBranches = new();

        [SerializeField] [Title("Else")] [HideLabel] [ShowIf(nameof(hasElse))]
        private SVInstruction elseInstruction;

        private string BranchesLabels => $"{instructionBranches.Count} Conditions";

        public async Task RunCondition(SVArgument argument)
        {
            var isInstructionExecute = false;
            foreach (var instructionBranch in instructionBranches)
            {
                var isBranchesPassed = instructionBranch.Branch.IsBranchesPassed(argument);
                if (isBranchesPassed && !instructionBranch.Branch.Not)
                {
                    isInstructionExecute = true;
                    await instructionBranch.Instruction.ExecuteInstructions(argument);
                }
                else if (!isBranchesPassed && instructionBranch.Branch.Not)
                {
                    isInstructionExecute = true;
                    await instructionBranch.Instruction.ExecuteInstructions(argument);
                }

                if (conditionType == SVConditionType.FirstIf && isInstructionExecute)
                {
                    return;
                }
            }

            if (hasElse && !isInstructionExecute)
            {
                await elseInstruction.ExecuteInstructions(argument);
            }
        }
    }
}