using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("Int")]
    [Serializable]
    public class SVVariableInt : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private int value;

        public override Type Type => typeof(int);

        protected override object Get()
        {
            return value;
        }

        protected override void Set(object newValue)
        {
            value = (int)newValue;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}