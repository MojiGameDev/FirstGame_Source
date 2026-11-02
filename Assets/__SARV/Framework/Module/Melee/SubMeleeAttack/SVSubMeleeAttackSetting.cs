using __SARV.Common.Base;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackSetting : SVScriptableObject
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnHit")] [HideLabel]
        private SVInstruction onHitInstruction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnBlocked")] [HideLabel]
        private SVInstruction onBlockedInstruction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("OnParried")] [HideLabel]
        private SVInstruction onParriedInstruction;

        private string GroupTitle => $"Title";

        public SVInstruction OnHitInstruction => onHitInstruction;
        public SVInstruction OnBlockedInstruction => onBlockedInstruction;
        public SVInstruction OnParriedInstruction => onParriedInstruction;
    }
}