using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("OnTriggerEnter")]
    [SVCategory(SVConstantCategory.Signal.PHYSICS)]
    [SVDescription("Executes when another collider enters the trigger")]
    [Serializable]
    public class SVPhysicsSignalOnTriggerEnter : SVSignalComponent
    {
        [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        public override void HandleOnTriggerEnter(SARVTrigger trigger, Collider other)
        {
            if (other.gameObject == target.GetValue(trigger.Argument).gameObject)
            {
                trigger.Execute();
            }
        }
    }
}