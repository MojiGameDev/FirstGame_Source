using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Common.Utils;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVIgnore]
    public class SVNullInstruction : SVInstructionComponent
    {
        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}