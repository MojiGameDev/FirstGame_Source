using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using UnityEngine;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnTriggerExit")]
    [SVCategory(SVConstantCategory.Signal.PHYSICS)]
    [SVDescription("Executes when another collider exits the trigger")]
    [Serializable]
    public class SVPhysicsSignalOnTriggerExit : SVSignalComponent
    {
        public override void HandleOnTriggerExit(SARVTrigger trigger, Collider other)
        {
            trigger.Invoke();
        }
    }
}