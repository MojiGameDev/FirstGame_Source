using System;
using __SARV.Framework.Module.State;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorStateMachine : SVSubActorCombat
    {
        [FoldoutGroup("StateMachine")] [SerializeField] [HideLabel]
        private SVStateMachine stateMachine;

        public SVStateMachine StateMachine => stateMachine;

        protected override void Awake()
        {
            base.Awake();
            StateMachine.HandleAwake();
        }

        protected override void Start()
        {
            base.Start();
            if (IsActorPlayer)
            {
                StateMachine.HandleStart();
            }
        }

        protected override void Update()
        {
            base.Update();
            StateMachine.HandleUpdate(Time.deltaTime);
        }
    }
}