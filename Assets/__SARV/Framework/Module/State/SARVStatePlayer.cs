using System;
using System.Collections.Generic;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Module.State.Behavior.Base;

namespace __SARV.Framework.Module.State
{
    public class SARVStatePlayer : SVBaseState
    {
        protected override List<string> GetAllBehaviorComponentPaths()
        {
            return SVReflection.GetAllBehaviorComponentPaths<SVPlayerBehavior>();
        }

        protected override Type GetBehaviorComponentByPath(string behaviorName)
        {
            return SVReflection.GetBehaviorComponentByPath<SVPlayerBehavior>(behaviorName);
        }
    }
}