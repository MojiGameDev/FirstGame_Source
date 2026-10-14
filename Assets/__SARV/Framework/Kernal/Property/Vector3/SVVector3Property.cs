using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Constant;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
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
            return GetValue(default).ToString();
        }
    }
}