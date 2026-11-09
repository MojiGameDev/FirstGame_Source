using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackReaction : SVSubMeleeAttackSetting
    {
        [FoldoutGroup("Event")] [SerializeField] [Title("OnHit")] [HideLabel]
        private SVInstruction onHitInstruction;
        
        public async Task ExecuteOnHit(SVArgument argument)
        {
            await onHitInstruction.ExecuteInstructions(argument);
        }
    }
}