using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("String")]
    [Serializable]
    public class SVVariableString : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private string value;

        public override Type Type => typeof(string);

        protected override object Get()
        {
            return value;
        }

        protected override void Set(object newValue)
        {
            value = value?.ToString() ?? string.Empty;
        }

        public override string ToString()
        {
            return value;
        }
    }
}