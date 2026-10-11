using System;
using __SARV.Core.Access;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Player;

namespace __SARV.Framework.Behavior.Base
{
    [Serializable]
    public class SVPlayerBehavior : SVBehaviorComponent
    {
        protected SARVPlayer Player => SVAccessPlayer.Instance;
    }
}