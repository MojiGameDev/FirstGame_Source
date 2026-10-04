using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.BOOL)]
    [SVDescription("True or False")]
    [Serializable]
    public class SVBoolPropertyManual : SVPropertyComponent<bool>
    {
        [SerializeField] [HideLabel]
        private bool value;

        public override bool Value => value;

        public override string ToString()
        {
            return Value ? "true" : "false";
        }
    }
}