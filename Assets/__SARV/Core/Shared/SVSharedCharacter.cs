using System;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Base;
using __SARV.Framework;
using __SARV.Framework.Argument;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace __SARV.Core.Shared
{
    [Serializable]
    public class SVSharedCharacter : SVSerializableMonoBehaviour
    {
        [BoxGroup("Debug")] [SerializeField] [ReadOnly]
        protected SVIdentifier currentStateIdentifier;

        [BoxGroup("Debug")] [SerializeField] [ReadOnly]
        protected List<string> trackStates = new();

        [BoxGroup("States")] [SerializeField] [ListDrawerSettings(ShowFoldout = false)] [OnValueChanged(nameof(OnBehaviorsChanged))] [PropertyOrder(int.MaxValue)]
        protected List<SARVState> states = new();

        protected SARVState _currentState;
        protected SARVState _previousState;
        protected bool _isStateChanged;
        protected readonly Dictionary<Type, SVIdentifier> UniqueStateIdentifier = new();
        private readonly Dictionary<SVIdentifier, SARVState> RuntimeStates = new();

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

            _currentState.BehaviorComponent.Tick(Time.deltaTime);
        }

        private void HandleDefaultState()
        {
            ChangeStateTo(RuntimeStates.First().Key);
        }

        public void ChangeStateTo(SVIdentifier stateIdentifier)
        {
            _previousState = _currentState;
            _previousState?.BehaviorComponent.Exit();
            OnExitState?.Invoke(currentStateIdentifier);

            _currentState = RuntimeStates[stateIdentifier];
            _currentState?.BehaviorComponent.Enter();
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
                state.BehaviorComponent.SetArgument(fromArgument);
            }
        }

        protected void OnBehaviorsChanged()
        {
        }

        private void HandleStatesToDictionary()
        {
            foreach (var state in states)
            {
                RuntimeStates.Add(state.BehaviorComponent.Identifier, state);
            }

            var uniqueStates = states
                .GroupBy(s => s.GetType())
                .Where(g => g.Count() == 1)
                .Select(g => g.First())
                .ToList();

            foreach (var state in uniqueStates)
            {
                UniqueStateIdentifier.Add(state.GetType(), state.BehaviorComponent.Identifier);
            }
        }
    }
}