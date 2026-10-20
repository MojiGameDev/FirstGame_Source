using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property.Actor
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.ACTOR)]
    [SVDescription("Enter a actor")]
    [Serializable]
    public class SVActorPropertyManual : SVPropertyComponent<SVActor>
    {
        [SerializeField] [HideLabel] private SVActor value;

        public override string ToString()
        {
            return $"Manual ({(value == null ? "..." : value.gameObject.name)})";
        }

        public override SVActor GetValue(SVArgument argument)
        {
            return value;
        }
    }
}