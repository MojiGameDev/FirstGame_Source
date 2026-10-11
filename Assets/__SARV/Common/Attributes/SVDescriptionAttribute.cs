using System;

namespace __SARV.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SVDescriptionAttribute : Attribute
    {
        public string Value { get; }

        public SVDescriptionAttribute(string value)
        {
            Value = value;
        }
    }
}