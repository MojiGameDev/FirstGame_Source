using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Service.Variable.Base;

namespace __SARV.Service.Variable.Value
{
    [SVIgnore]
    [Serializable]
    public class SVVariableValueNull : SVVariableValue
    {
        protected override object GetValue()
        {
            return null;
        }

        protected override void SetValue(object newValue)
        {
            
        }

        public override string ToString()
        {
            return "Null";
        }
    }
}