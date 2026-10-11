using System;
using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Core.Reflection;
using __SARV.Framework.Behavior.Base;

namespace __SARV.Framework
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