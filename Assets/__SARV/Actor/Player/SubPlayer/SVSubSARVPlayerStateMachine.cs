using __SARV.Core.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerStateMachine : SVSubSARVPlayerAnimancer
    {
        [FoldoutGroup("StateMachine")] [SerializeField] [HideLabel]
        private SVSharedStateMachine sharedStateMachine;

        public SVSharedStateMachine SharedStateMachine => sharedStateMachine;

        protected override void Awake()
        {
            base.Awake();
            SharedStateMachine.HandleAwake();
        }

        protected override void Start()
        {
            base.Start();
            SharedStateMachine.HandleStart();
        }

        protected override void Update()
        {
            base.Update();
            SharedStateMachine.HandleUpdate(Time.deltaTime);
        }
    }
}