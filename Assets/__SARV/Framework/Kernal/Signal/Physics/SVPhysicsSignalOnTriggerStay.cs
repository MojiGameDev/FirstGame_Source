using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using UnityEngine;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnTriggerStay")]
    [SVCategory(SVConstantCategory.Signal.PHYSICS)]
    [SVDescription("Executes while another collider stays inside the trigger")]
    [Serializable]
    public class SVPhysicsSignalOnTriggerStay : SVSignalComponent
    {
        public override void HandleOnTriggerStay(Collider other)
        {
            Handler.Invoke(SVArgument.FromCollider(other));
        }
    }
}