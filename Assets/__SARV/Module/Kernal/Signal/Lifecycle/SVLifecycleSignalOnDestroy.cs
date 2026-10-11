using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;

namespace __SARV.Framework.Signal
{
    [SVTitle("OnDestroy")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called when the trigger is being destroyed")]
    [Serializable]
    public class SVLifecycleSignalOnDestroy : SVSignalComponent
    {
        
    }
}