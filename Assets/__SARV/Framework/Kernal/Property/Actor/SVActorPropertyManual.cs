using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Actor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.ACTOR)]
    [SVDescription("Enter a actor")]
    [Serializable]
    public class SVActorPropertyManual : SVPropertyComponent<SARVActor>
    {
        [SerializeField] [HideLabel] private SARVActor value;

        public override string ToString()
        {
            return $"Manual ({(value == null ? "..." : value.transform.parent.name)})";
        }

        public override SARVActor GetValue(SVArgument argument)
        {
            return value;
        }
    }
}