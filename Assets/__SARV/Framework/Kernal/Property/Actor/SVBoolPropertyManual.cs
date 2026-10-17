using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property.Actor
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.ACTOR)]
    [SVDescription("Enter a actor")]
    [Serializable]
    public class SVBoolPropertyManual : SVPropertyComponent<SVActor>
    {
        [SerializeField] [HideLabel] private SVActor value;

        public override string ToString()
        {
            return value.gameObject.name;
        }

        public override SVActor GetValue(SVArgument argument)
        {
            return value;
        }
    }
}