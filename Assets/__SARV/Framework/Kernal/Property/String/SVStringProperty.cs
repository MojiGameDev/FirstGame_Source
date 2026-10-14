using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("String")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Includes all properties that are composed of strings")]
    [SVIgnore]
    [Serializable]
    public class SVStringProperty : SVParentProperty<string>
    {
        public override string ToString()
        {
            return propertyType.ToString();
        }
    }
}