using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackReaction : SVSubMeleeAttackSetting
    {
        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnEnableStrike")] [HideLabel]
        private SVInstruction onEnableStrikeInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnDisableStrike")] [HideLabel]
        private SVInstruction onDisableStrikeInstruction;

        public async Task ExecuteOnEnableStrike(SVArgument argument)
        {
            await onEnableStrikeInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteOnDisableStrike(SVArgument argument)
        {
            await onDisableStrikeInstruction.ExecuteInstructions(argument);
        }
    }
}