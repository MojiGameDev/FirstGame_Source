using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnEnable")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called whenever the trigger becomes enabled and active")]
    [Serializable]
    public class SVLifecycleSignalOnEnable : SVSignalComponent
    {
        public override void HandleOnEnable(SARVTrigger trigger)
        {
            trigger.Execute();
        }
    }
}