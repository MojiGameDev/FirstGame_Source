using System;
using System.Collections.Generic;
using __SARV.Framework.Integration.Animancer.Wrapper;
using __SARV.Framework.Module.Identifier;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorAnimancer : SVSubActorFootstep
    {
      [FoldoutGroup("Animancer")]  [SerializeField] [TableList]
        private List<SVWrapperAnimancerIdentifier> wrappers = new();

        private AnimancerState _currentAnimancerState;
        public readonly Dictionary<SARVIdentifier, StringAsset> RuntimeAnimancerAlias = new();

        protected override void Awake()
        {
            base.Awake();
            HandleWrappersToDictionary();
        }

        public void PlayAnimancer(SARVIdentifier identifier, Action onEnd = null)
        {
            var alias = RuntimeAnimancerAlias[identifier];
            _currentAnimancerState = animancerComponent.TryPlay(alias);

            if (onEnd != null)
            {
                _currentAnimancerState.Events(this).OnEnd = onEnd;
            }
        }

        private void HandleWrappersToDictionary()
        {
            foreach (var wrapper in wrappers)
            {
                RuntimeAnimancerAlias.Add(wrapper.Identifier, wrapper.Alias);
            }
        }
    }
}