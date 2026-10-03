using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using UnityEngine;

namespace __SARV.Framework.Signal
{
    [SVTitle("OnAwake")]
    [SVCategory(SVConstantCategory.Signal.LIFECYCLE)]
    [SVDescription("Called when the trigger is initialized")]
    [Serializable]
    public class SVLifecycleSignalOnAwake : SVSignalComponent
    {
        public override void HandleAwake()
        {
            Debug.Log("HandleAwake");
        }
    }
}