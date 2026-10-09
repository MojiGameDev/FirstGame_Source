using System;
using __SARV.Core.Attributes;
using __SARV.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Value
{
    [SVTitle("Int")]
    [Serializable]
    public class SVVariableValueInt : SVVariableValue
    {
        [SerializeField] [HideLabel] private int value;

        protected override object GetValue()
        {
            return value;
        }

        protected override void SetValue(object newValue)
        {
            value = (int)newValue;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}