using System;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable.Value
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