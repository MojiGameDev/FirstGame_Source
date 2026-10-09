using System;
using __SARV.Core.Attributes;
using __SARV.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Value
{
    [SVTitle("Vector3")]
    [Serializable]
    public class SVVariableValueVector3 : SVVariableValue
    {
        [SerializeField] [HideLabel] private Vector3 value;

        protected override object GetValue()
        {
            return value;
        }

        protected override void SetValue(object newValue)
        {
            value = value is var cast ? cast : Vector3.zero;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}