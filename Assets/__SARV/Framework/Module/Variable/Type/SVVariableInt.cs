using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Integration.EasySave;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("Int")]
    [Serializable]
    public class SVVariableInt : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel] [OnValueChanged(nameof(OnInspectorValueChanged))]
        private int value;

        public override Type Type => typeof(int);

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