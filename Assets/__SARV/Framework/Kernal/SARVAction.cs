using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal
{
    public class SARVAction : SVKernal
    {
        [SerializeField] [HideLabel] private SVInstruction instruction;
        
        public async Task RunAction()
        {
            await instruction.ExecuteInstructions(SVArgument.Create(gameObject));
        }
    }
}