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
    [SVCategory(SVConstantCategory.Property.FLOAT)]
    [SVDescription("Enter a float")]
    [Serializable]
    public class SVFloatPropertyManual : SVPropertyComponent<float>
    {
        [SerializeField] [HideLabel] private float value;
        
        public override string ToString()
        {
            return $"Manual ({value})";
        }

        public override float GetValue(SVArgument argument)
        {
            return value;
        }
    }
}