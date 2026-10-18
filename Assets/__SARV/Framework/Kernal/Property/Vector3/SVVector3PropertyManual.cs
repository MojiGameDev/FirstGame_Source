using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.VECTOR3)]
    [SVDescription("Enter a vector3")]
    [Serializable]
    public class SVVector3PropertyManual : SVPropertyComponent<Vector3>
    {
        [SerializeField] [HideLabel]
        private Vector3 value = Vector3.zero;
        
        public override string ToString()
        {
            return $"Manual({value})";
        }

        public override Vector3 GetValue(SVArgument argument)
        {
            return value;
        }
    }
}