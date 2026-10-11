using System.Threading.Tasks;
using UnityEngine;

namespace __SARV.Framework.Common.Utils
{
    public static class SVTaskUtils
    {
        public static readonly Task OK_RESULT = Task.FromResult(true);
        
        public static async Task Wait(float duration, bool realTime)
        {
            float startTime = GetTime(realTime);

            while (GetTime(realTime) < startTime + duration)
            {
                await Task.Yield();
            }
        }

        private static float GetTime(bool realTime)
        {
            return realTime ? Time.unscaledTime : Time.time;
        }
    }
}