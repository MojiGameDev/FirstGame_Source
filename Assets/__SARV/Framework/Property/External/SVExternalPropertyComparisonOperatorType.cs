using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("ComparisonOperatorType")]
    [SVCategory(SVConstantCategory.Property.EXTERNAL)]
    [SVDescription("The type of comparison operator")]
    [Serializable]
    [SVIgnore]
    public class SVExternalPropertyComparisonOperatorType : SVPropertyComponent<SVComparisonOperatorType>
    {
        [SerializeField] [HideLabel] private SVComparisonOperatorType value = SVComparisonOperatorType.Equal;

        public override SVComparisonOperatorType Value => value;

        public override string ToString()
        {
            return value.ToString();
        }
    }
}