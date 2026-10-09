using System;
using __SARV.Core.Attributes;
using __SARV.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Value
{
    [SVTitle("String")]
    [Serializable]
    public class SVVariableValueString : SVVariableValue
    {
        [SerializeField] [HideLabel] private string value;

        protected override object GetValue()
        {
            return value;
        }

        protected override void SetValue(object newValue)
        {
            value = value?.ToString() ?? string.Empty;
        }

        public override string ToString()
        {
            return value;
        }
    }
}