using System;

namespace __SARV.Common.Base
{
    [Serializable]
    public abstract class SVSerializableLifeCycle : SVSerializable
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

        public virtual void HandleLateUpdate(float deltaTime)
        {
        }

        protected virtual void HandleOnDisable()
        {
        }

        public virtual void HandleOnDestroy()
        {
        }

        public virtual void HandleOnDrawGizmos()
        {
        }

        public virtual void HandleOnDrawGizmosSelected()
        {
        }
    }
}