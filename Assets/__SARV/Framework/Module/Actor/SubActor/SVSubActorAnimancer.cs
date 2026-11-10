using System;
using Animancer;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorAnimancer : SVSubActorFootstep
    {
        private AnimancerState _currentAnimancerState;

        public void PlayAnimancer(StringAsset alias, Action onEnd = null, bool restart = false)
        {
            _currentAnimancerState = animancerComponent.TryPlay(alias);
            if (_currentAnimancerState == null)
            {
                return;
            }

            if (restart)
            {
                _currentAnimancerState.Time = 0;
            }

            if (onEnd != null)
            {
                _currentAnimancerState.Events(this).OnEnd = onEnd;
            }
        }
    }
}