using System;
using __SARV.Framework.Enum;

namespace __SARV.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SVCategoryAttribute : Attribute
    {
        public SVTriggerCategory Value { get; }

        public SVCategoryAttribute(SVTriggerCategory value)
        {
            Value = value;
        }
    }
}