using System;
using __SARV.Core.Base;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Base
{
    [Serializable]
    public abstract class SVValue : SVSerializable
    {
        public event Action<object> EventChange;

        public object Value
        {
            get => this.GetValue();
            set
            {
                if (this.GetValue() == value)
                {
                    return;
                }

                this.SetValue(value);
                this.EventChange?.Invoke(this.GetValue());
            }
        }

        protected abstract object GetValue();
        protected abstract void SetValue(object value);
    }
}