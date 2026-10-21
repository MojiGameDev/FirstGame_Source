using System;
using __SARV.Actor.Player;
using __SARV.Common.Access;
using __SARV.Framework.Common.Component;

namespace __SARV.Framework.Module.State.Behavior.Base
{
    [Serializable]
    public abstract class SVPlayerBehavior : SVBehaviorComponent
    {
        protected SARVPlayer Player => SVAccessPlayer.Instance;
    }
}