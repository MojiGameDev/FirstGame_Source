using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Enter a vector3")]
    [Serializable]
    public class SVVector3PropertyManual : SVPropertyComponent<Vector3>
    {
        [SerializeField] [HideLabel]
        private Vector3 value = Vector3.zero;

        public override Vector3 Value => value;

        public override string ToString()
        {
            return $"Manual({Value})";
        }
    }
}