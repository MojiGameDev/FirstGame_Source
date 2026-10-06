using System;
using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Identifier;
using __SARV.Wrapper.Entity;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Wrapper
{
    [Serializable]
    public class SVAnimancerWrapper : SVSharedCharacter
    {
        [SerializeField] [TableList] private List<SVAnimancerIdentifier> wrappers = new();

        private AnimancerState _currentAnimancerState;
        private AnimancerComponent _animancer;

        public AnimancerState CurrentAnimancerState => _currentAnimancerState;
        public readonly Dictionary<SVIdentifier, StringAsset> RuntimeAlias = new();

        public override void HandleAwake()
        {
            HandleWrappersToDictionary();
        }

        public void SetAnimancerComponent(AnimancerComponent animancer)
        {
            _animancer = animancer;
        }

        public void PlayTransition(SVIdentifier identifier, Action onEnd = null)
        {
            var alias = RuntimeAlias[identifier];
            _currentAnimancerState = _animancer.TryPlay(alias);

            if (onEnd != null)
            {
                _currentAnimancerState.Events(this).OnEnd = onEnd;
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