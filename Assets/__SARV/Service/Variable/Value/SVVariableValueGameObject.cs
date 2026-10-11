using System;
using __SARV.Core.Attributes;
using __SARV.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Value
{
    [SVTitle("GameObject")]
    [Serializable]
    public class SVVariableValueGameObject : SVVariableValue
    {
        [SerializeField] [HideLabel] private GameObject value;

        protected override object GetValue()
        {
            return value;
        }

        protected override void SetValue(object newValue)
        {
            value = value as GameObject;
        }

        public override string ToString()
        {
            return value != null ? value.name : "(none)";
        }
    }
}