using System.Collections.Generic;
using UnityEngine;

namespace __MD.Script.Core.Extension
{
    public static class MDVectorExtension
    {
        /// <summary>
        /// Returns a Vector3 where each component is:
        /// -1 if less than 0, 
        ///  0 if equal to 0, 
        ///  1 if greater than 0.
        /// </summary>
        public static Vector3 Sign(this Vector3 vector)
        {
            return new Vector3(
                Mathf.Sign(vector.x),
                Mathf.Sign(vector.y),
                Mathf.Sign(vector.z)
            );
        }

        /// <summary>
        /// Returns a Vector2 where each component is:
        /// -1 if less than 0, 
        ///  0 if equal to 0, 
        ///  1 if greater than 0.
        /// </summary>
        public static Vector2 Sign(this Vector2 vector)
        {
            return new Vector2(
                Mathf.Sign(vector.x),
                Mathf.Sign(vector.y)
            );
        }

        /// <summary>
        /// Checks if two Vector2 are approximately equal within a given tolerance.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>True if the vectors are approximately equal.</returns>
        public static bool ApproximatelyEquals(this Vector2 v1, Vector2 v2)
        {
            return Vector2.SqrMagnitude(v1 - v2) < MDNumberExtension.DEFAULT_THRESHOLD * MDNumberExtension.DEFAULT_THRESHOLD;
        }

        /// <summary>
        /// Checks if only the Z component of the vector is greater than the specified threshold,
        /// while the X and Y components are effectively zero (within a given tolerance).
        /// </summary>
        /// <param name="vector">The Vector3 to check.</param>
        /// <param name="threshold">
        /// The minimum value the Z component must exceed. 
        /// Default is 0.8.
        /// </param>
        /// <returns>
        /// True if Z is greater than the threshold and X and Y are approximately zero; otherwise, false.
        /// </returns>
        public static bool IsOnlyZGreaterThan(this Vector3 vector, float threshold = 0.8f)
        {
            return vector.z > threshold
                   && Mathf.Abs(vector.x) < MDNumberExtension.DEFAULT_THRESHOLD
                   && Mathf.Abs(vector.y) < MDNumberExtension.DEFAULT_THRESHOLD;
        }

        public static float GetRandomBetween(this Vector2 source)
        {
            return Random.Range(source.x, source.y);
        }

        public static int GetRandomBetween(this Vector2Int source)
        {
            return Random.Range(source.x, source.y);
        }
        
        public static float DistanceTo(this Vector3 from, Vector3 to)
        {
            return Vector3.Distance(from, to);
        }
        
        public static Vector3 GetClosestPosition(this List<Vector3> positions, Vector3 targetPosition)
        {
            var closest = Vector3.zero;
            var closestSqrDistance = Mathf.Infinity;

            foreach (var position in positions)
            {
                var sqrDist = (position - targetPosition).sqrMagnitude;
                if (sqrDist < closestSqrDistance)
                {
                    closestSqrDistance = sqrDist;
                    closest = position;
                }
            }

            return closest;
        }

        public static bool HasValue(this Vector3 source)
        {
            return source.magnitude.HasValue();
        }
    }
}