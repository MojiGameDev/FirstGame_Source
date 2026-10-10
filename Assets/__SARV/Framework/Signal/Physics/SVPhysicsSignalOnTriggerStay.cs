using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Argument;
using UnityEngine;

namespace __SARV.Framework.Signal
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