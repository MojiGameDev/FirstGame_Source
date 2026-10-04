using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Framework.Argument;

namespace __SARV.Framework.Branch
{
    [SVIgnore]
    [Serializable]
    public class SVNullBranch : SVBranchComponent
    {
        public override bool IsTrue(SVArgument argument)
        {
            return false;
        }
    }
}