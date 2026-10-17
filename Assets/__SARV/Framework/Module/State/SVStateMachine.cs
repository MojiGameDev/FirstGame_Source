using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.State.Base;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace __SARV.Framework.Module.State
{
    [Serializable]
    public class SVStateMachine : SVSerializableLifeCycle
    {
        [BoxGroup("Debug")] [SerializeField] [ReadOnly]
        private SARVIdentifier currentStateIdentifier;

        [BoxGroup("Debug")] [SerializeField] [ReadOnly]
        private List<string> trackStates = new();

        [BoxGroup("States")] [SerializeField] [ListDrawerSettings(ShowFoldout = false)] [OnValueChanged(nameof(OnBehaviorsChanged))] [PropertyOrder(int.MaxValue)]
        private List<SVBaseState> states = new();

        private SVBaseState _currentState;
        private SVBaseState _previousState;
        private bool _isStateChanged;
        private readonly Dictionary<Type, SARVIdentifier> _uniqueStateIdentifier = new();
        private readonly Dictionary<SARVIdentifier, SVBaseState> _runtimeStates = new();

        protected UnityEvent<string> OnEnterState;
        protected UnityEvent<string> OnExitState;
        protected UnityEvent<string, string> OnChangeState;

        public override void HandleAwake()
        {
            HandleStatesToDictionary();
        }

        public override void HandleStart()
        {
            HandleDefaultState();
        }

        public override void HandleUpdate(float deltaTime)
        {
            if (_isStateChanged)
            {
                _isStateChanged = false;
                return;
            }

            _currentState.Behavior.Tick(deltaTime);
        }

        private void HandleDefaultState()
        {
            _ = EnterToNewState(_runtimeStates.First().Key);
        }

        public void ChangeBehaviorTo(SARVIdentifier stateIdentifier)
        {
            _ = ChangeStateToInternal(stateIdentifier);
        }

        private async Task ChangeStateToInternal(SARVIdentifier stateIdentifier)
        {
            await ExitFromOldState();
            await EnterToNewState(stateIdentifier);
        }

        private async Task ExitFromOldState()
        {
            _previousState = _currentState;
            await _previousState.Behavior.Exit();
            OnExitState?.Invoke(currentStateIdentifier);
        }

        private async Task EnterToNewState(SARVIdentifier stateIdentifier)
        {
            _currentState = _runtimeStates[stateIdentifier];
            await _currentState.Behavior.Enter();
            OnEnterState?.Invoke(stateIdentifier);
            OnChangeState?.Invoke(currentStateIdentifier, stateIdentifier);
            currentStateIdentifier = stateIdentifier;
            trackStates.Add(currentStateIdentifier);
            _isStateChanged = true;
        }

        protected void OnBehaviorsChanged()
        {
        }

        private void HandleStatesToDictionary()
        {
            foreach (var state in states)
            {
                _runtimeStates.Add(state.Behavior.Identifier, state);
            }

            var uniqueStates = states
                .GroupBy(s => s.GetType())
                .Where(g => g.Count() == 1)
                .Select(g => g.First())
                .ToList();

            foreach (var state in uniqueStates)
            {
                _uniqueStateIdentifier.Add(state.GetType(), state.Behavior.Identifier);
            }
        }
    }
}