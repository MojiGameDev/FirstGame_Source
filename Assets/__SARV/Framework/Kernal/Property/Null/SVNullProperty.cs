using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;

namespace __SARV.Framework.Kernal.Property
{
    [SVIgnore]
    public class SVNullProperty<TType> : SVPropertyComponent<TType>
    {
        public override string ToString()
        {
            return "Null";
        }

        public override TType GetValue(SVArgument argument)
        {
            return default;
        }
    }
}