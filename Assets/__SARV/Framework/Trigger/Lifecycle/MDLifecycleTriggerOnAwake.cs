using __SARV.Core.Attributes;
using __SARV.Core.Constant;
using __SARV.Framework.Component;
using UnityEngine;

namespace __SARV.Framework.Trigger
{
    [SVTitle("OnAwake")]
    [SVCategory(SVConstantCategory.Trigger.LIFECYCLE)]
    [SVDescription("...")]
    public class MDLifecycleTriggerOnAwake : SVTriggerComponent
    {
        public override void HandleAwake()
        {
            Debug.Log("HandleAwake");
        }
    }
}