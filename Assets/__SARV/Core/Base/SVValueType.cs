using System;

namespace __SARV.Core.Base
{
    [Serializable]
    public abstract class SVValueType<TType>
    {
        public virtual TType Value { get; }
    }
}