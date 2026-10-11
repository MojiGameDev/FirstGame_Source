using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Argument;
using UnityEngine;

namespace __SARV.Framework.Signal
{
    [SVTitle("OnTriggerEnter")]
    [SVCategory(SVConstantCategory.Signal.PHYSICS)]
    [SVDescription("Executes when another collider enters the trigger")]
    [Serializable]
    public class SVPhysicsSignalOnTriggerEnter : SVSignalComponent
    {
        public override void HandleOnTriggerEnter(Collider other)
        {
            Handler.Invoke(SVArgument.FromCollider(other));
        }
    }
}