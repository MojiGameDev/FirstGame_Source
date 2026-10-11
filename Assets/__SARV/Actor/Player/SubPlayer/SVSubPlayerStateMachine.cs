using __SARV.Actor.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerStateMachine : SVSubPlayerAnimancer
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
            StateMachine.HandleStart();
        }

        protected override void Update()
        {
            base.Update();
            StateMachine.HandleUpdate(Time.deltaTime);
        }
    }
}