using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("GameObject")]
    [Serializable]
    public class SVVariableGameObject : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private GameObject value;

        public override Type Type => typeof(GameObject);

        protected override object Get()
        {
            return value;
        }

        protected override void Set(object newValue)
        {
            value = value as GameObject;
        }

        public override string ToString()
        {
            return value != null ? value.name : "(none)";
        }
    }
}