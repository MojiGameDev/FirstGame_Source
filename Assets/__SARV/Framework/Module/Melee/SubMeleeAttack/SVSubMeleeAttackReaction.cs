using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackReaction : SVSubMeleeAttackSetting
    {
        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnStart")] [HideLabel]
        private SVInstruction onStartInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnHit")] [HideLabel]
        private SVInstruction onHitInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnEnd")] [HideLabel]
        private SVInstruction onEndInstruction;

        public async Task ExecuteOnStart(SVArgument argument)
        {
            await onStartInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteOnHit(SVArgument argument)
        {
            await onHitInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteOnEnd(SVArgument argument)
        {
            await onEndInstruction.ExecuteInstructions(argument);
        }
    }
}