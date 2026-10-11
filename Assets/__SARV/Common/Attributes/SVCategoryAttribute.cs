using System;

namespace __SARV.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SVCategoryAttribute : Attribute
    {
        public string Value { get; }

        public SVCategoryAttribute(string value)
        {
            Value = value;
        }
    }
}