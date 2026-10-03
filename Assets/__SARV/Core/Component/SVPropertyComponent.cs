using System;
using __SARV.Core.Component.Base;

namespace __SARV.Core.Component
{
    [Serializable]
    public class SVPropertyComponent<TType> : SVComponent
    {
        public virtual TType Value { get; }
    }
}