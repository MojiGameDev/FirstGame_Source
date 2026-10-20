using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public abstract class SVSetterComponent<TType> : SVComponent
    {
        public abstract void SetValue(SVArgument argument, TType value);
    }
}