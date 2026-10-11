using System.Threading.Tasks;
using __SARV.Core.Base;
using __SARV.Core.Shared;
using __SARV.Framework.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVAction : SVMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";

        [SerializeField] [HideLabel] private SVSharedInstruction sharedInstruction;
        
        public async Task RunAction(SVArgument argument)
        {
            await sharedInstruction.ExecuteInstructions(argument);
        }
    }
}