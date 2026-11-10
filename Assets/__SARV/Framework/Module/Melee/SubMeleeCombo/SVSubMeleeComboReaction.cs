using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeCombo
{
    public abstract class SVSubMeleeComboReaction : SVScriptableObject
    {
        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnStart")] [HideLabel]
        private SVInstruction onStartInstruction;

        [FoldoutGroup("Reaction")] [SerializeField] [Title("OnEnd")] [HideLabel]
        private SVInstruction onEndInstruction;

        public async Task ExecuteOnStart(SVArgument argument)
        {
            await onStartInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteOnEnd(SVArgument argument)
        {
            await onEndInstruction.ExecuteInstructions(argument);
        }
    }
}