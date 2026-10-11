using System;
using __SARV.Framework.Common.Base;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public class SVPropertyComponent<TType> : SVComponent
    {
        public virtual TType Value { get; }
    }
}