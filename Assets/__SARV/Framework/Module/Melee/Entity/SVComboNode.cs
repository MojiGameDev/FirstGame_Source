using System;
using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.Entity
{
    [Serializable]
    public class SVComboNode : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("CanPerform?")] [HideLabel]
        private SVBranch onCanPerformBranch;
        
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnStart")] [HideLabel]
        private SVInstruction onStartInstruction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnEnd")] [HideLabel]
        private SVInstruction onEndInstruction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnHit")] [HideLabel]
        private SVInstruction onHitInstruction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnBlocked")] [HideLabel]
        private SVInstruction onBlockedInstruction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnParried")] [HideLabel]
        private SVInstruction onParriedInstruction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [LabelText("$" + nameof(CombosLabel))] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [Title("")] [PropertySpace(spaceBefore: -15)]
        private List<SVComboNode> combos = new();

        private string CombosLabel => $"{combos.Count} Sub Combos";
        private string GroupTitle => $"Title";

        public SVBranch OnCanPerformBranch => onCanPerformBranch;
        public SVInstruction OnStartInstruction => onStartInstruction;
        public SVInstruction OnEndInstruction => onEndInstruction;
        public SVInstruction OnHitInstruction => onHitInstruction;
        public SVInstruction OnBlockedInstruction => onBlockedInstruction;
        public SVInstruction OnParriedInstruction => onParriedInstruction;

        private void CreateNode()
        {
            combos.Add(new SVComboNode());
        }
    }
}