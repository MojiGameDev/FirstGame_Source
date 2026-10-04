using System;
using __SARV.Core.Component.Base;
using __SARV.Framework.Argument;
using UnityEngine;

namespace __SARV.Core.Component
{
    [Serializable]
    public class SVSignalComponent : SVComponent
    {
        protected Action<SVArgument> Handler;

        public void SetHandler(Action<SVArgument> handler)
        {
            Handler = handler;
        }

        public virtual void HandleAwake()
        {
            
        }

        public virtual void HandleOnEnable()
        {
            
        }

        public virtual void HandleStart()
        {
            
        }

        public virtual void HandleUpdate(float deltaTime)
        {
            
        }

        public virtual void HandleFixedUpdate(float fixedDeltaTime)
        {
            
        }

        public virtual void HandleOnDestroy()
        {
            
        }

        public virtual void HandleOnDisable()
        {
            
        }

        public virtual void HandleOnTriggerEnter(Collider other)
        {
            
        }

        public virtual void HandleOnTriggerStay(Collider other)
        {
            
        }

        public virtual void HandleOnTriggerExit(Collider other)
        {
            
        }
    }
}