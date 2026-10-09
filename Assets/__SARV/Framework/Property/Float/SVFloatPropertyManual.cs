using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.FLOAT)]
    [SVDescription("Enter a float")]
    [Serializable]
    public class SVFloatPropertyManual : SVPropertyComponent<float>
    {
        [SerializeField] [HideLabel] private float value = 0f;

        public override float Value => value;

        public override string ToString()
        {
            return $"Manual({Value})";
        }
    }
}