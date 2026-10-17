using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnAwake")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called when the trigger is initialized")]
    [Serializable]
    public class SVLifecycleSignalOnAwake : SVSignalComponent
    {
        public override void HandleAwake(SARVTrigger trigger)
        {
            trigger.Execute();
        }
    }
}