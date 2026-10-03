using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;

namespace __SARV.Framework.Signal
{
    [SVTitle("OnFixedUpdate")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called at fixed time intervals, primarily for physics updates")]
    [Serializable]
    public class SVLifecycleSignalOnFixedUpdate : SVSignalComponent
    {
        
    }
}