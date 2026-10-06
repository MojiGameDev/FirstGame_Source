using System;
using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Core.Shared.Entity;
using __SARV.Identifier;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Shared
{
    [Serializable]
    public class SVSharedAnimancer : SVSerializableMonoBehaviour
    {
        [SerializeField] [TableList] private List<SVAnimancerIdentifier> wrappers = new();

        private AnimancerState _currentState;
        private AnimancerComponent _animancer;

        public AnimancerState CurrentState => _currentState;
        public readonly Dictionary<SVIdentifier, StringAsset> RuntimeAlias = new();
        
        public override void HandleAwake()
        {
            HandleWrappersToDictionary();
        }

        public void SetAnimancerComponent(AnimancerComponent animancer)
        {
            _animancer = animancer;
        }

        public void Play(SVIdentifier identifier, Action onEnd = null)
        {
            var alias = RuntimeAlias[identifier];
            _currentState = _animancer.TryPlay(alias);

            if (onEnd != null)
            {
                _currentState.Events(this).OnEnd = onEnd;
            }
        }

        private void HandleWrappersToDictionary()
        {
            foreach (var wrapper in wrappers)
            {
                RuntimeAlias.Add(wrapper.Identifier, wrapper.Alias);
            }
        }
    }
}