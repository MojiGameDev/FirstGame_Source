using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;

namespace __SARV.Framework.Branch
{
    [SVIgnore]
    [Serializable]
    public class SVNullBranch : SVBranchComponent
    {
        public override bool IsTrue()
        {
            return false;
        }
    }
}