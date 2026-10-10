using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Argument;
using UnityEngine;

namespace __SARV.Framework.Signal
{
    [SVTitle("OnTriggerExit")]
    [SVCategory(SVConstantCategory.Signal.PHYSICS)]
    [SVDescription("Executes when another collider exits the trigger")]
    [Serializable]
    public class SVPhysicsSignalOnTriggerExit : SVSignalComponent
    {
        public override void HandleOnTriggerExit(Collider other)
        {
            Handler.Invoke(SVArgument.FromCollider(other));
        }
    }
}