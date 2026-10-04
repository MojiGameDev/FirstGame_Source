using System.Threading.Tasks;
using __SARV.Core.Base;
using __SARV.Framework.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVAction : SVInstructionMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";

        public async Task RunAction(SVArgument argument)
        {
            await ExecuteInstructions(argument);
        }
    }
}