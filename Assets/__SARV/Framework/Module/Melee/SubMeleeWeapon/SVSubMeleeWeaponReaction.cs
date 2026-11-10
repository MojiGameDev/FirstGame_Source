using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeWeapon
{
    public abstract class SVSubMeleeWeaponReaction : SVSubMeleeShieldHandling
    {
        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnBlocked")] [HideLabel]
        private SVInstruction onBlockedInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnParried")] [HideLabel]
        private SVInstruction onParriedInstruction;
        
        public async Task ExecuteOnBlocked(SVArgument argument)
        {
            await onBlockedInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteOnParried(SVArgument argument)
        {
            await onParriedInstruction.ExecuteInstructions(argument);
        }
    }
}