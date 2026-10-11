using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnDestroy")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called when the trigger is being destroyed")]
    [Serializable]
    public class SVLifecycleSignalOnDestroy : SVSignalComponent
    {
        
    }
}