using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeShield
{
    public abstract class SVSubMeleeShieldDefence : SVSubMeleeShieldHandling
    {
        [FoldoutGroup("Defence")] [SerializeField] [Title("OnBlock")] [HideLabel]
        private SVInstruction onBlockInstruction;

        [FoldoutGroup("Defence")] [SerializeField] [Title("OnBreak")] [HideLabel]
        private SVInstruction onBreakInstruction;

        [FoldoutGroup("Defence")] [SerializeField] [Title("OnnParry")] [HideLabel]
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