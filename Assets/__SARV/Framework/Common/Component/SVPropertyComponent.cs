using System;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Kernal.Argument;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public abstract class SVPropertyComponent<TType> : SVComponent
    {
        public abstract TType GetValue(SVArgument argument);
    }
}