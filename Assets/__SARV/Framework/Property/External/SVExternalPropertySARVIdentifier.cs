using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("SARVIdentifier")]
    [SVCategory(SVConstantCategory.Property.EXTERNAL)]
    [SVDescription("The type of SARVIdentifier")]
    [Serializable]
    [SVIgnore]
    public class SVExternalPropertySARVIdentifier : SVPropertyComponent<SARVIdentifier>
    {
        [SerializeField] [HideLabel] private SARVIdentifier value;

        public override SARVIdentifier Value => value;

        public override string ToString()
        {
            return "SARVIdentifier";
        }
    }
}