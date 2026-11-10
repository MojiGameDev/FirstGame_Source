using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeShield
{
    public abstract class SVSubMeleeShieldReaction : SVSubMeleeShieldHandling
    {
        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnBlock")] [HideLabel]
        private SVInstruction onBlockInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnBreak")] [HideLabel]
        private SVInstruction onBreakInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnParry")] [HideLabel]
        private SVInstruction onParryInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnDamage")] [HideLabel]
        private SVInstruction onDamageInstruction;

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

        public async Task ExecuteOnDamage(SVArgument argument)
        {
            await onDamageInstruction.ExecuteInstructions(argument);
        }
    }
}