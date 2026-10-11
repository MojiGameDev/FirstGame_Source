using System;
using __SARV.Core.Attributes;
using __SARV.Core.Extension;
using __SARV.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Value
{
    [SVTitle("Bool")]
    [Serializable]
    public class SVVariableValueBool : SVVariableValue
    {
        [SerializeField] [HideLabel] private bool value;

        protected override object GetValue()
        {
            return value;
        }

        protected override void SetValue(object newValue)
        {
            value = newValue is true;
        }

        public override string ToString()
        {
            return value.ToName();
        }
    }
}