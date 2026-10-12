using System;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Integration.OdinInspector.Runtime;

namespace __SARV.Framework.Common.Component
{
    [Serializable]
    public class SVPropertyComponent<TType> : SVComponent
    {
        public virtual TType Value { get; }
    }
}