using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Kernal.Argument;
using __SARV.Framework.Kernal.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal
{
    public class SARVAction : SVKernal
    {
        [SerializeField] [HideLabel] private SVInstruction instruction;
        
        public async Task RunAction(SVArgument argument)
        {
            await instruction.ExecuteInstructions(argument);
        }
    }
}