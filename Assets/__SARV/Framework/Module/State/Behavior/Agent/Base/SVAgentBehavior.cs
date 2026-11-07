using System;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Actor.Access;

namespace __SARV.Framework.Module.State.Behavior.Agent.Base
{
    [Serializable]
    public abstract class SVPlayerBehavior : SVBehaviorComponent
    {
        protected SARVActor Agent => SVAccessPlayer.Instance;
    }
}