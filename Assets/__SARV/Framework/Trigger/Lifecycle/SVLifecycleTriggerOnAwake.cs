using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using UnityEngine;

namespace __SARV.Framework.Trigger
{
    [SVTitle("OnAwake")]
    [SVCategory(SVConstantCategory.Trigger.LIFECYCLE)]
    [SVDescription("Called when the trigger is initialized")]
    [Serializable]
    public class SVLifecycleTriggerOnAwake : SVTriggerComponent
    {
        public override void HandleAwake()
        {
            Debug.Log("HandleAwake");
        }
    }
}