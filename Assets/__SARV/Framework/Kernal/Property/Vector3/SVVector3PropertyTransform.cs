using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("TransformPosition")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Returns the world position of a referenced Transform as a Vector3")]
    [Serializable]
    public class SVVector3PropertyTransform : SVPropertyComponent<Vector3>
    {
        [SerializeField] [HideLabel] private Transform value;

        public override string ToString()
        {
            return GetPosition().ToString();
        }

        public override Vector3 GetValue(SVArgument argument)
        {
            return GetPosition();
        }

        private Vector3 GetPosition()
        {
            return value != null ? value.position : Vector3.zero;
        }
    }
}