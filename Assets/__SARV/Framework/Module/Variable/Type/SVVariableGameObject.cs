using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Integration.EasySave;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("GameObject")]
    [Serializable]
    public class SVVariableGameObject : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel] [OnValueChanged(nameof(OnInspectorValueChanged), InvokeOnInitialize = true)]
        private GameObject value;

        public override Type Type => typeof(GameObject);

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