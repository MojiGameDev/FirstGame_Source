using __SARV.Common.Base;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackEvent : SVSubMeleeAttackSetting
    {
        [FoldoutGroup("Event")] [SerializeField] [Title("OnHit")] [HideLabel]
        private SVInstruction onHitInstruction;

        [FoldoutGroup("Event")] [SerializeField] [Title("OnBlocked")] [HideLabel]
        private SVInstruction onBlockedInstruction;

        [FoldoutGroup("Event")] [SerializeField] [Title("OnParried")] [HideLabel]
        private SVInstruction onParriedInstruction;
        
        public SVInstruction OnHitInstruction => onHitInstruction;
        public SVInstruction OnBlockedInstruction => onBlockedInstruction;
        public SVInstruction OnParriedInstruction => onParriedInstruction;
    }
}