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
        private List<SVBranch> branches = new();

        [SerializeField] [Title("Else")] [HideLabel] [ShowIf(nameof(hasElse))]
        private SVInstruction elseInstruction;

        private string BranchesLabels => $"{branches.Count} Conditions";

        public async Task RunCondition(SVArgument argument)
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