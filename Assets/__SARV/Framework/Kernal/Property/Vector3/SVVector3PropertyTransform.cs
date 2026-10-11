using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Transform")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Returns the world position of a referenced Transform as a Vector3")]
    [Serializable]
    public class SVVector3PropertyTransform : SVPropertyComponent<Vector3>
    {
        [SerializeField] [HideLabel] private Transform value;

        public override Vector3 Value => value.position;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}