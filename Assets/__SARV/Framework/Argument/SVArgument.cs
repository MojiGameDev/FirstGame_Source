using System;
using System.Reflection;
using __SARV.Agent;
using __SARV.Player;
using UnityEngine;

namespace __SARV.Framework.Argument
{
    public readonly struct SVArgument
    {
        public readonly float DeltaTime;
        public readonly Collider Collider;
        public readonly SARVAgent SARVAgent;

        private SVArgument(float deltaTime, Collider collider, SARVAgent sarvAgent)
        {
            DeltaTime = deltaTime;
            Collider = collider;
            SARVAgent = sarvAgent;
        }

        public static SVArgument Empty() => new(0f, null, null);
        public static SVArgument FromDeltaTime(float value) => new(value, null, null);
        public static SVArgument FromCollider(Collider value) => new(0f, value, null);
        public static SVArgument FromSARVAgent(SARVAgent value) => new(0f, null, value);

        public static SVArgument FromArgument<T>(T value)
        {
            var method = typeof(SVArgument).GetMethod($"From{typeof(T).Name}", BindingFlags.Public | BindingFlags.Static);
            if (method == null)
            {
                throw new InvalidOperationException($"No factory found for {typeof(T).Name}");
            }

            return (SVArgument)method.Invoke(null, new object[] { value });
        }
    }
}