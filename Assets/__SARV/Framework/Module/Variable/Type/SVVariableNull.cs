using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Variable.Base;

namespace __SARV.Framework.Module.Variable
{
    [SVIgnore]
    [Serializable]
    public class SVVariableNull : SVVariable
    {
        public override Type Type => null;
        
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