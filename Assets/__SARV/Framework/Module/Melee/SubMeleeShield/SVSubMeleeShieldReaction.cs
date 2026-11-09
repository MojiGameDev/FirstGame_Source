using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeShield
{
    public abstract class SVSubMeleeShieldReaction : SVSubMeleeShieldHandling
    {
        [FoldoutGroup("Shield")] [SerializeField] [Title("OnBlock")] [HideLabel]
        private SVInstruction onBlockInstruction;

        [FoldoutGroup("Shield")] [SerializeField] [Title("OnBreak")] [HideLabel]
        private SVInstruction onBreakInstruction;

        [FoldoutGroup("Shield")] [SerializeField] [Title("OnParry")] [HideLabel]
        private SVInstruction onParryInstruction;

        public async Task ExecuteOnBlock(SVArgument argument)
        {
            await onBlockInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteOnBreak(SVArgument argument)
        {
            await onBreakInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteOnParry(SVArgument argument)
        {
            await onParryInstruction.ExecuteInstructions(argument);
        }
    }
}