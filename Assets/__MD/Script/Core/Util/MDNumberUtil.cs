using __MD.Script.Core.Extension;
using UnityEngine;
using Random = UnityEngine.Random;

namespace __MD.Script.Core.Util
{
    public static class MDNumberUtil
    {
        public static float ClampAngle(float a, float min, float max)
        {
            while (max < min)
                max += 360.0f;

            while (a > max)
                a -= 360.0f;

            while (a < min)
                a += 360.0f;

            return a > max ? a - (max + min) * 0.5f < 180.0f ? max : min : a;
        }

        public static bool HasMagnitude(float x, float y)
        {
            var vector2 = new Vector2(x, y);
            return vector2.magnitude.HasValue();
        }

        public static Vector2 CreateVector2(float x, float y)
        {
            return new Vector2(x, y);
        }
        
        public static float RandomBetween(Vector2 range)
        {
            return Random.Range(Mathf.Min(range.x, range.y), Mathf.Max(range.x, range.y));
        }
    }
}