using __MD.Script.Core.Base;
using __MD.Script.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.Core.StateMachine.Base
{
    public abstract class MDBaseState : MDScriptableObject
    {
        [FoldoutGroup("StateIdentifier")] [SerializeField] [HideLabel]
        private MDIdentifier identifier;
        
        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void Exit();
        public abstract void OnGizmos();

        public MDIdentifier Identifier => identifier;
    }
}