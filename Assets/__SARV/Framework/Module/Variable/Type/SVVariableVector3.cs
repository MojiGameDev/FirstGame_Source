using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Integration.EasySave;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("Vector3")]
    [Serializable]
    public class SVVariableVector3 : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel] [OnValueChanged(nameof(OnInspectorValueChanged))]
        private Vector3 value;

        public override Type Type => typeof(Vector3);

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