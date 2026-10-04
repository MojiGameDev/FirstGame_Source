using UnityEngine;

namespace __SARV.Framework.Argument
{
    public readonly struct SVArgument
    {
        public readonly float DeltaTime;
        public readonly Collider Collider;

        private SVArgument(float deltaTime, Collider collider)
        {
            DeltaTime = deltaTime;
            Collider = collider;
        }

        public static SVArgument Empty() => new(0f, null);

        public static SVArgument FromDeltaTime(float value) => new(value, null);
        
        public static SVArgument FromCollider(Collider value) => new(0f, value);
    }
}