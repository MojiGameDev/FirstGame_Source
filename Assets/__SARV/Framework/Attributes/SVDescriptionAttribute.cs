using System;

namespace __SARV.Framework.Attributes
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