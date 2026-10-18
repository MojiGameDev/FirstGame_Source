using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public abstract class SVPropertyComponent<TType> : SVComponent
    {
        public abstract TType GetValue(SVArgument argument);
    }
}