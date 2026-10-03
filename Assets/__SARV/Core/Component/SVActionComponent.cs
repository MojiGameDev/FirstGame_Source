using System;
using System.Threading.Tasks;
using __SARV.Core.Component.Base;
using UnityEngine;

namespace __SARV.Core.Component
{
    [Serializable]
    public abstract class SVActionComponent : SVComponent
    {
        protected static readonly Task OkResult = Task.FromResult(true);
        
        public abstract Task Execute();
        
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