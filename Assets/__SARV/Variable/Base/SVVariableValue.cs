using System;
using __SARV.Core.Base;

namespace __SARV.Variable.Base
{
    [Serializable]
    public abstract class SVVariableValue : SVSerializable
    {
        public event Action<object> OnValueChanged;

        public object Value
        {
            get => GetValue();
            set
            {
                if (GetValue() == value)
                {
                    return;
                }

                SetValue(value);
                OnValueChanged?.Invoke(GetValue());
            }
        }

        protected abstract object GetValue();
        protected abstract void SetValue(object newValue);
        public abstract override string ToString();
    }
}