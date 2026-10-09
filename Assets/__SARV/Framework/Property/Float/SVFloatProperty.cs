using System;
using System.Globalization;
using __SARV.Core.Attributes;
using __SARV.Core.Base;
using __SARV.Core.Constant;

namespace __SARV.Framework.Property
{
    [SVTitle("Float")]
    [SVCategory(SVConstantCategory.Property.FLOAT)]
    [SVDescription("Includes all properties that are composed of float")]
    [SVIgnore]
    [Serializable]
    public class SVFloatProperty : SVParentProperty<float>
    {
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}