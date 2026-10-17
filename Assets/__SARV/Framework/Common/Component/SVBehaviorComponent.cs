using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Kernal.Argument;
using __SARV.Framework.Kernal.Shared;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public abstract class SVBehaviorComponent : SVComponent
    {
        [BoxGroup("Identifier")] [SerializeField] [HideLabel]
        private SARVIdentifier identifier;

        [SerializeField] [Title("OnEnter")] [HideLabel]
        private SVInstruction onEnterInstruction;

        [SerializeField] [Title("OnExit")] [HideLabel] [PropertySpace(0, 10)]
        private SVInstruction onExitInstruction;

        public SARVIdentifier Identifier => identifier;

        protected SVArgument Argument;

        public void SetArgument(SVArgument argument)
        {
            Argument = argument;
        }

        public virtual async Task Enter()
        {
            await onEnterInstruction.ExecuteInstructions(Argument);
        }

        public virtual void Tick(float deltaTime)
        {
        }

        public virtual async Task Exit()
        {
            await onEnterInstruction.ExecuteInstructions(Argument);
        }

        public void OnDrawGizmosSelected()
        {
        }
    }
}