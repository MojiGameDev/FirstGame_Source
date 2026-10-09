using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
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