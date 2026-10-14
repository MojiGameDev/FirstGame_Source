using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Up")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Represents a read-only property that always returns Vector3.up (0, 1, 0)")]
    [Serializable]
    public class SVVector3PropertyUp : SVPropertyComponent<Vector3>
    {
        public override string ToString()
        {
            return Vector3.up.ToString();
        }

        public override Vector3 GetValue(SVArgument argument)
        {
            return Vector3.up;
        }
    }
}