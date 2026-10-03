using System;
using __SARV.Core.Component.Base;
using UnityEngine;

namespace __SARV.Core.Component
{
    [Serializable]
    public abstract class SVTriggerComponent : SVComponent
    {
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

        public virtual void HandleFixedUpdate(float deltaTime)
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