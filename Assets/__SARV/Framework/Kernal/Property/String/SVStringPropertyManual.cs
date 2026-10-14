using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Enter a text")]
    [Serializable]
    public class SVStringPropertyManual : SVPropertyComponent<string>
    {
        [SerializeField] [HideLabel] private string value;

        public override string ToString()
        {
            return value;
        }

        public override string GetValue(SVArgument argument)
        {
            return value;
        }
    }
}