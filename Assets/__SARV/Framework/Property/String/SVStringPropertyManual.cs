using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("Manual")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Enter a text")]
    [Serializable]
    public class SVStringPropertyManual : SVPropertyComponent<string>
    {
        [SerializeField] [HideLabel]
        private string value;

        public override string Value => value;

        public override string ToString()
        {
            return $"Manual({Value})";
        }
    }
}