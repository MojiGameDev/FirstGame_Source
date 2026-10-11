using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
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