using __SARV.Framework.Module.Identifier;

namespace Ilumisoft.VisualStateMachine
{
    using UnityEngine;

    [System.Serializable]
    public class State : Node
    {
        [SerializeField] private SARVIdentifier identifier;
        
        public SARVIdentifier Identifier => this.identifier;
    }
}