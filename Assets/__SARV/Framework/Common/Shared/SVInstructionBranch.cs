using System;
using __SARV.Common.Base;
using __SARV.Common.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Shared
{
    [Serializable]
    public class SVInstructionBranch : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private SVBranch branch;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Executes when the branches are true")]
        private string trueTooltip = "";

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private SVInstruction instruction;

        private string GroupTitle => $"Type : {branch.ConditionJoinType.ToReadableString()} - {branch.BranchesCount} Branches - {instruction.InstructionsCount} Instructions";
        public SVBranch Branch => branch;
        public SVInstruction Instruction => instruction;
    }
}