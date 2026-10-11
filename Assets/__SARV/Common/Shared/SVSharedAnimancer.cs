using System;
using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Core.Wrapper;
using __SARV.Identifier;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Shared
{
    [Serializable]
    public class SVSharedAnimancer : SVSerializableMonoBehaviour
    {
        [SerializeField] [TableList]
        private List<SVWrapperAnimancerIdentifier> wrappers = new();

        private AnimancerState _currentState;
        private AnimancerComponent _animancer;

        public AnimancerState CurrentState => _currentState;
        public readonly Dictionary<SARVIdentifier, StringAsset> RuntimeAlias = new();

        public override void HandleAwake()
        {
            HandleWrappersToDictionary();
        }

        public void SetAnimancerComponent(AnimancerComponent animancer)
        {
            _animancer = animancer;
        }

        public void Play(SARVIdentifier identifier, Action onEnd = null)
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