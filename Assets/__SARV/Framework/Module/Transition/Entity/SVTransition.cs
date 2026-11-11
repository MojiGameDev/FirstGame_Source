using System;
using __SARV.Common.Base;
using __SARV.Framework.Common.Shared;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Transition.Entity
{
    [Serializable]
    public class SVTransition : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/ToState", showLabel: false)] [SerializeField] [HideLabel]
        private SARVIdentifier behavior;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private SVBranch branch;

        private string GroupTitle => $"To {(string.IsNullOrEmpty(behavior) ? "..." : behavior.SkipWords(2))} when {branch.BranchesCount} Branches are True";
        public SARVIdentifier Behavior => behavior;
        public SVBranch Branch => branch;
    }
}