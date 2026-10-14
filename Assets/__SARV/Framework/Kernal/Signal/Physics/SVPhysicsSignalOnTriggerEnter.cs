using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using UnityEngine;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnTriggerEnter")]
    [SVCategory(SVConstantCategory.Signal.PHYSICS)]
    [SVDescription("Executes when another collider enters the trigger")]
    [Serializable]
    public class SVPhysicsSignalOnTriggerEnter : SVSignalComponent
    {
        public override void HandleOnTriggerEnter(SARVTrigger trigger, Collider other)
        {
            trigger.Invoke();
        }
    }
}