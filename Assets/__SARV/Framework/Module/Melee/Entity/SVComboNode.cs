using System;
using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.Entity
{
    [Serializable]
    public class SVComboNode : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Attack", showLabel: false)] [SerializeField] [Required]
        private SARVMeleeAttack attack;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("CanPerform?")] [HideLabel]
        private SVBranch onCanPerformBranch;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [LabelText("$" + nameof(CombosLabel))] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [Title("")] [PropertySpace(spaceBefore: -15)]
        private List<SVComboNode> combos = new();

        private string CombosLabel => $"{combos.Count} Sub Combos";
        private string GroupTitle => $"Title";

        public SARVMeleeAttack Attack => attack;
        public SVBranch OnCanPerformBranch => onCanPerformBranch;
        public IReadOnlyList<SVComboNode> Combos => combos;

        public bool CanPerform(SVArgument argument)
        {
            return onCanPerformBranch.IsBranchesPassed(argument);
        }
        
        private void CreateNode()
        {
            combos.Add(new SVComboNode());
        }
    }
}