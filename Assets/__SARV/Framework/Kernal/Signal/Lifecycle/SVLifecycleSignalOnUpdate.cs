using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnUpdate")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called once every frame")]
    [Serializable]
    public class SVLifecycleSignalOnUpdate : SVSignalComponent
    {
        public override void HandleUpdate(SARVTrigger trigger)
        {
            trigger.Execute();
        }
    }
}