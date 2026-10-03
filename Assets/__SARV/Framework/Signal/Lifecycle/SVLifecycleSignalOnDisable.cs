using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;

namespace __SARV.Framework.Signal
{
    [SVTitle("OnDisable")]
    [SVCategory(SVConstantCategory.Trigger.LIFECYCLE)]
    [SVDescription("Called whenever the trigger becomes disabled or inactive")]
    [Serializable]
    public class SVLifecycleSignalOnDisable : SVSignalComponent
    {
        
    }
}