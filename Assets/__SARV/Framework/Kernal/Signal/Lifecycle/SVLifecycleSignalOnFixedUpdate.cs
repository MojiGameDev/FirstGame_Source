using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnFixedUpdate")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called at fixed time intervals, primarily for physics updates")]
    [Serializable]
    public class SVLifecycleSignalOnFixedUpdate : SVSignalComponent
    {
        public override void HandleFixedUpdate(SARVTrigger trigger)
        {
            trigger.Invoke();
        }
    }
}