using System;
using System.Collections.Generic;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Module.State.Base;
using __SARV.Framework.Module.State.Behavior.Agent.Base;

namespace __SARV.Framework.Module.State
{
    public class SARVStateAgent : SVBaseState
    {
        protected override List<string> GetAllBehaviorComponentPaths()
        {
            return SVReflection.GetAllBehaviorComponentPaths<SVAgentBehavior>();
        }

        protected override Type GetBehaviorComponentByPath(string behaviorName)
        {
            return SVReflection.GetBehaviorComponentByPath<SVAgentBehavior>(behaviorName);
        }
    }
}