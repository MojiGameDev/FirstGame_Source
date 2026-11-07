namespace Ilumisoft.VisualStateMachine
{
    using UnityEngine;

    /// <summary>
    /// Base class to create custom behaviours for states
    /// </summary>
    public abstract class StateBehaviour : MonoBehaviour
    {
        [SerializeField]
        StateMachine stateMachine;

        State state = null;

        /// <summary>
        /// ID of the state this behaviour is belonging to
        /// </summary>
        public abstract string StateID { get; }

        /// <summary>
        /// The State Machine owning the state this behaviour is belonging to
        /// </summary>
        public StateMachine StateMachine { get => this.stateMachine; set => this.stateMachine = value; }

        protected virtual void Awake()
        {
            
        }

        protected virtual void OnDestroy()
        {
            
        }

        /// <summary>
        /// Automatically tries to assign a state machine, when the component gets created or reset
        /// </summary>
        private void Reset()
        {
            if (StateMachine == null)
            {
                StateMachine = GetComponentInParent<StateMachine>();
            }
        }

        /// <summary>
        /// Returns true if the state is the currently active one
        /// </summary>
        public bool IsActiveState => StateMachine.CurrentState == StateID;

        /// <summary>
        /// Callback invoked when the state is entered
        /// </summary>
        protected virtual void OnEnterState() { }
    }
}