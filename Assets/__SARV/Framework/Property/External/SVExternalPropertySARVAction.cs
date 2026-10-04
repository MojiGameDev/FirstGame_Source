using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("SARVAction")]
    [SVCategory(SVConstantCategory.Property.EXTERNAL)]
    [SVDescription("The type of SARVAction")]
    [Serializable]
    [SVIgnore]
    public class SVExternalPropertySARVAction : SVPropertyComponent<SARVAction>
    {
        [SerializeField] [HideLabel] private SARVAction value;

        public override SARVAction Value => value;

        public override string ToString()
        {
            return Value == null ? "..." : Value.gameObject.name;
        }
    }
}