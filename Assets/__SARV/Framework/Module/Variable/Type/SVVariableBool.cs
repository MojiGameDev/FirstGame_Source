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
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private bool value;

        public override Type Type => typeof(bool);

        protected override object Get()
        {
            return value;
        }

        protected override void Set(object newValue)
        {
            value = newValue is true;
        }

        protected override void Save()
        {
            SVEasySave.Save(key, value);
        }

        protected override void Load()
        {
            Value = ES3.Load<bool>(key);
        }

        public override string ToString()
        {
            return value.ToName();
        }
    }
}