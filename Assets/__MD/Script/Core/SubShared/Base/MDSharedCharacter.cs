using System;
using __MD.Script.Core.Base;

namespace __MD.Script.Core.SubShared.Base
{
    [Serializable]
    public abstract class MDSharedCharacter : MDSerializable
    {
        public virtual void HandleAwake()
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

        public virtual void HandleDestroy()
        {
        }

        public virtual void HandleDrawGizmos()
        {
        }

        public virtual void HandleDrawGizmosSelected()
        {
        }
    }
}