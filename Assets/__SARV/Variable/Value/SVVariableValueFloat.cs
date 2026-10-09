using System;
using System.Globalization;
using __SARV.Core.Attributes;
using __SARV.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Value
{
    [SVTitle("Float")]
    [Serializable]
    public class SVVariableValueFloat : SVVariableValue
    {
        [SerializeField] [HideLabel] private float value;

        protected override object GetValue()
        {
            return value;
        }

        protected override void SetValue(object newValue)
        {
            value = (float)newValue;
        }

        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}