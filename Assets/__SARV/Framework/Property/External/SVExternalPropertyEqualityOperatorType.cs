using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("EqualityOperatorType")]
    [SVCategory(SVConstantCategory.Property.EXTERNAL)]
    [SVDescription("The type of equality operator")]
    [Serializable]
    [SVIgnore]
    public class SVExternalPropertyEqualityOperatorType : SVPropertyComponent<SVEqualityOperatorType>
    {
        [SerializeField] [HideLabel] private SVEqualityOperatorType value = SVEqualityOperatorType.Equal;

        public override SVEqualityOperatorType Value => value;

        public override string ToString()
        {
            return value.ToString();
        }
    }
}