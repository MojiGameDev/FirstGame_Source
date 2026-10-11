using System;
using System.Globalization;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Constant;

namespace __SARV.Framework.Kernal.Property
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