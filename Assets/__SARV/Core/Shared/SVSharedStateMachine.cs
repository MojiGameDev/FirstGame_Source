using System;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Framework;
using __SARV.Framework.Argument;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace __SARV.Core.Shared
{
    [Serializable]
    public class SVSharedStateMachine : SVSerializableMonoBehaviour
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
            ChangeStateTo(_runtimeStates.First().Key);
        }

        public void ChangeStateTo(SARVIdentifier stateIdentifier)
        {
            _previousState = _currentState;
            _previousState?.Behavior.Exit();
            OnExitState?.Invoke(currentStateIdentifier);

            _currentState = _runtimeStates[stateIdentifier];
            _currentState?.Behavior.Enter();
            OnEnterState?.Invoke(stateIdentifier);
            OnChangeState?.Invoke(currentStateIdentifier, stateIdentifier);
            currentStateIdentifier = stateIdentifier;
            trackStates.Add(currentStateIdentifier);
            _isStateChanged = true;
        }

        public void SetArgument<TCharacter>(TCharacter character)
        {
            foreach (var state in states)
            {
                var fromArgument = SVArgument.FromArgument(character);
                state.Behavior.SetArgument(fromArgument);
            }
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