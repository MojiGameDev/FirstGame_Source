using System;
using __SARV.Core.Attributes;
using __SARV.Core.Base;
using __SARV.Core.Constant;
using __SARV.Core.Extension;

namespace __SARV.Framework.Property
{
    [SVTitle("Bool")]
    [SVCategory(SVConstantCategory.Property.BOOL)]
    [SVDescription("Includes all properties that are composed of booleans")]
    [SVIgnore]
    [Serializable]
    public class SVBoolProperty : SVParentProperty<bool>
    {
        public override string ToString()
        {
            if (IsPropertyHasValue && !IsPropertyComponentNull)
            {
                return IsPropertyHasValue ? $"{property} ({Value.ToName()})" : "...";
            }

            return IsPropertyHasValue ? property : "...";
        }
    }
}