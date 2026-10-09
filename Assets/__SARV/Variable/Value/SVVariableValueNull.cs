using System;
using __SARV.Core.Attributes;
using __SARV.Variable.Base;

namespace __SARV.Variable.Value
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