using System;
using __SARV.Core.Attributes;
using __SARV.Core.Base;
using __SARV.Core.Constant;

namespace __SARV.Framework.Property
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
            return Value.ToString();
        }
    }
}