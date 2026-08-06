using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace __MD.Script.Core.Extension
{
    public static class MDNumberExtension
    {
        public const float DEFAULT_THRESHOLD = 0.001f;

        public static bool HasValue(this float value)
        {
            return value > DEFAULT_THRESHOLD;
        }

        public static float ClampAngle(this float value, float min, float max)
        {
            if (value < -360f)
            {
                value += 360f;
            }

            if (value > 360f)
            {
                value -= 360f;
            }

            return Mathf.Clamp(value, min, max);
        }

        public static bool ApproximatelyEquals(this float f1, float f2)
        {
            return Mathf.Approximately(f1, f2);
        }

        public static int GetClosestIndex(this List<Vector3> positions, Vector3 targetPosition)
        {
            var closestSqrDistance = Mathf.Infinity;
            int closestIndex = -1;
            for (var index = 0; index < positions.Count; index++)
            {
                var position = positions[index];
                var sqrDist = (position - targetPosition).sqrMagnitude;
                if (sqrDist < closestSqrDistance)
                {
                    closestSqrDistance = sqrDist;
                    closestIndex = index;
                }
            }

            return closestIndex;
        }

        public static Vector3 GetClosestPosition(this Vector3[] positions, Vector3 targetPosition)
        {
            return positions.ToList().GetClosestPosition(targetPosition);
        }

        public static int GetClosestIndex(this Vector3[] positions, Vector3 targetPosition)
        {
            return positions.ToList().GetClosestIndex(targetPosition);
        }
    }
}