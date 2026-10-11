using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnDisable")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called whenever the trigger becomes disabled or inactive")]
    [Serializable]
    public class SVLifecycleSignalOnDisable : SVSignalComponent
    {
        
    }
}