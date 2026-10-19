using System;
using System.Globalization;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    [SVTitle("Float")]
    [Serializable]
    public class SVVariableFloat : SVVariable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private float value;

        public override Type Type => typeof(float);

        protected override object Get()
        {
            return value;
        }

        protected override void Set(object newValue)
        {
            value = (float)newValue;
        }

        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}