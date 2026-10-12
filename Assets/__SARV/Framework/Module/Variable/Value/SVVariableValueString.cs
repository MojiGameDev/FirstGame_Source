using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable.Value
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