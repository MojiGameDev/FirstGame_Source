using System.Threading.Tasks;

namespace __SARV.Framework.Common.Entity
{
    public class SVInstructionResult
    {
        public bool Break { get; private set; }

        private static readonly SVInstructionResult DEFAULT = new()
        {
            Break = false
        };

        private static readonly SVInstructionResult BREAK_EXECUTION = new()
        {
            Break = true
        };

        public static readonly Task<SVInstructionResult> DEFAULT_RESULT = Task.FromResult(DEFAULT);

        public static readonly Task<SVInstructionResult> BREAK_EXECUTION_RESULT = Task.FromResult(BREAK_EXECUTION);
    }
}