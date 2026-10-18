using UnityEngine;

namespace __SARV.Framework.Common.Argument
{
    public readonly struct SVArgument
    {
        public GameObject Self { get; }
        public object Value { get; }

        public SVArgument(GameObject self, object value = null)
        {
            Self = self;
            Value = value;
        }

        public static SVArgument Create(GameObject self) => new(self, null);
        public static SVArgument Create(GameObject self, object value) => new(self, value);

        public T GetValue<T>()
        {
            return Value is T value ? value : default;
        }
    }
}