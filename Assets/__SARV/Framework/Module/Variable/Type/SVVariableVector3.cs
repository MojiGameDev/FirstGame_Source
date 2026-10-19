using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("Vector3")]
    [Serializable]
    public class SVVariableVector3 : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private Vector3 value;

        public override Type Type => typeof(Vector3);

        protected override object Get()
        {
            return value;
        }

        protected override void Set(object newValue)
        {
            value = value is var cast ? cast : Vector3.zero;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}