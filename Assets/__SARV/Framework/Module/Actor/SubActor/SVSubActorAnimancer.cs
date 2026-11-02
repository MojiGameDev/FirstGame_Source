using System;
using Animancer;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorAnimancer : SVSubActorFootstep
    {
        private AnimancerState _currentAnimancerState;

        protected override void Awake()
        {
            base.Awake();
        }

        public void PlayAnimancer(StringAsset alias, Action onEnd = null)
        {
            _currentAnimancerState = animancerComponent.TryPlay(alias);

            if (onEnd != null)
            {
                _currentAnimancerState.Events(this).OnEnd = onEnd;
            }
        }
    }
}