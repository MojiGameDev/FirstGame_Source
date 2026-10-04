using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("SARVCondition")]
    [SVCategory(SVConstantCategory.Property.EXTERNAL)]
    [SVDescription("The type of SARVCondition")]
    [Serializable]
    [SVIgnore]
    public class SVExternalPropertySARVCondition : SVPropertyComponent<SARVCondition>
    {
        [SerializeField] [HideLabel] private SARVCondition value;

        public override SARVCondition Value => value;

        public override string ToString()
        {
            return "SARVCondition";
        }
    }
}