using __SARV.Core.Attributes;
using __SARV.Core.Component;

namespace __SARV.Framework.Property
{
    [SVIgnore]
    public class SVNullProperty<TType> : SVPropertyComponent<TType>
    {
        public override TType Value => default;

        public override string ToString()
        {
            return "Null";
        }
    }
}