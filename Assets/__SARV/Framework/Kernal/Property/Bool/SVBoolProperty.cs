using System;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Property
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