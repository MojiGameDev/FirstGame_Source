using System;
using __SARV.Core.Component.Base;

namespace __SARV.Core.Component
{
    [Serializable]
    public class SVBranchComponent : SVComponent
    {
        public virtual bool IsTrue()
        {
            return false;
        }
    }
}