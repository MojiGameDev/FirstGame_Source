using System;
using System.Threading.Tasks;
using __SARV.Core.Component.Base;
using __SARV.Framework.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Component
{
    [Serializable]
    public class SVInstructionComponent : SVComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [LabelText("Disabled?")]
        private bool disabled;

        protected virtual string GroupTitle => string.Empty;
        protected static readonly Task OkResult = Task.FromResult(true);
        public bool Disabled => disabled;

        public virtual Task Execute(SVArgument argument)
        {
            if (Disabled)
            {
                return OkResult;
            }
            return ExecuteInternal(argument);
        }

        protected virtual Task ExecuteInternal(SVArgument argument)
        {
            return OkResult;
        }

        protected async Task Wait(float duration, bool realTime)
        {
            var startTime = GetTime(realTime);
            while ((realTime ? Time.time : Time.unscaledTime) < startTime + duration)
            {
                await Task.Yield();
            }
        }

        private static float GetTime(bool realTime)
        {
            return realTime ? Time.time : Time.unscaledTime;
        }
    }
}