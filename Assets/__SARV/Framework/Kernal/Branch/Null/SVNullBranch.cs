using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;

namespace __SARV.Framework.Kernal.Branch
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