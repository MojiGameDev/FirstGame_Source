using System;
using __SARV.Core.Base;
using __SARV.Core.Component.Base;
using __SARV.Framework.Argument;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Component
{
    [Serializable]
    public class SVBehaviorComponent : SVComponent
    {
        protected SVArgument Argument;

        public void SetArgument(SVArgument argument)
        {
            Argument = argument;
        }

        public virtual void Enter()
        {
        }

        public virtual void Tick(float deltaTime)
        {
        }

        public virtual void Exit()
        {
        }

        public void OnDrawGizmosSelected()
        {
        }
    }
}