using System;

namespace __SARV.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SVTitleAttribute : Attribute
    {
        public string Value { get; }

        public SVTitleAttribute(string value)
        {
            Value = value;
        }
    }
}