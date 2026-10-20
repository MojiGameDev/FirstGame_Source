using System;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Integration.EasySave;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("Bool")]
    [Serializable]
    public class SVVariableBool : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel] [OnValueChanged(nameof(OnInspectorValueChanged))]
        private bool value;

        public override Type Type => typeof(bool);
        
        
        

        protected override object GetValue()
        {
            Debug.Log($"Get Bool | Instance: {GetHashCode()} | Value: {value}");
            return value;
        }

        protected override void SetValue(object newValue)
        {
            Debug.Log($"Set Bool | Instance: {GetHashCode()} | Incoming: {newValue} | Before: {value}");

            value = newValue is true;

            Debug.Log($"Set Bool | Instance: {GetHashCode()} | After: {value}");
        }

        public override string ToString()
        {
            return value.ToName();
        }
    }
}