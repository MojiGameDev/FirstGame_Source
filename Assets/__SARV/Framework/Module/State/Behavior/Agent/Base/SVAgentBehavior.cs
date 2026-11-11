using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Module.Transition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior.Agent.Base
{
    [Serializable]
    public abstract class SVAgentBehavior : SVBehaviorComponent
    {
        [BoxGroup("Transition")] [SerializeField] [HideLabel] [PropertyOrder(-9)]
        private SARVTransition transition;

        private bool _isTransitionPerformed;
        public bool IsBehaviorFinished { get; protected set; }

        public override Task Enter()
        {
            _isTransitionPerformed = false;
            IsBehaviorFinished = false;
            return base.Enter();
        }

        public override void Tick(float deltaTime)
        {
            if (_isTransitionPerformed)
            {
                return;
            }

            _isTransitionPerformed = transition.Evaluate(Argument);
        }
    }
}