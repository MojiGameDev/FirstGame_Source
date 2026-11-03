using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeWeapon
{
    public abstract class SVSubMeleeWeaponShield : SVScriptableObject
    {
        [FoldoutGroup("Shield")] [SerializeField] [Title("OnBlock")] [HideLabel]
        private SVInstruction onBlockInstruction;

        [FoldoutGroup("Shield")] [SerializeField] [Title("OnBreak")] [HideLabel]
        private SVInstruction onBreakInstruction;

        [FoldoutGroup("Shield")] [SerializeField] [Title("OnnParry")] [HideLabel]
        private SVInstruction onParryInstruction;
        
        public async Task ExecuteBlock(SVArgument argument)
        {
            await onBlockInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteBreak(SVArgument argument)
        {
            await onBreakInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteParry(SVArgument argument)
        {
            await onParryInstruction.ExecuteInstructions(argument);
        }
    }
}