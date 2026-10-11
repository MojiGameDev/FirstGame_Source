using System;
using __SARV.Core.Attributes;
using __SARV.Core.Base;
using __SARV.Core.Constant;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("Vector3")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Includes all properties that are composed of vector3")]
    [SVIgnore]
    [Serializable]
    public class SVVector3Property : SVParentProperty<Vector3>
    {
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}