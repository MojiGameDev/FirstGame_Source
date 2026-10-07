using System;
using __SARV.Variable.Base;

namespace __SARV.Variable.Value
{
    [Serializable]
    public class SVValueNull : SVValue
    {
        protected override object GetValue()
        {
            return null;
        }

        protected override void SetValue(object value)
        {
            
        }

        public override string ToString()
        {
            return "Null";
        }
    }
}