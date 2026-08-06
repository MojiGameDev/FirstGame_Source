using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace __MD.Script.Core.Extension
{
    public static class MDTransformExtension
    {
        public static float DistanceTo(this Transform from, Transform to)
        {
            return Vector3.Distance(from.position, to.position);
        }

        public static void Hide(this Transform target)
        {
            target.gameObject.Hide();
        }

        public static void Show(this Transform target)
        {
            target.gameObject.Show();
        }

        /// <summary>
        /// Recursively searches for a child Transform by name.
        /// </summary>
        /// <param name="parent">The parent Transform to search from.</param>
        /// <param name="name">The name of the child to find.</param>
        /// <returns>The found Transform, or null if not found.</returns>
        public static Transform FindDeepChild(this Transform parent, string name)
        {
            foreach (Transform child in parent)
            {
                if (child.name == name)
                {
                    return child;
                }

                var result = child.FindDeepChild(name);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public static Transform GetClosestTransform(this List<Transform> points, Vector3 targetPosition)
        {
            Transform closest = null;
            var closestSqrDistance = Mathf.Infinity;

            foreach (var t in points)
            {
                var sqrDist = (t.position - targetPosition).sqrMagnitude;
                if (sqrDist < closestSqrDistance)
                {
                    closestSqrDistance = sqrDist;
                    closest = t;
                }
            }

            return closest;
        }

        public static int GetClosestIndex(this List<Transform> points, Vector3 targetPosition)
        {
            var closestSqrDistance = Mathf.Infinity;
            int closestIndex = -1;
            for (var index = 0; index < points.Count; index++)
            {
                var t = points[index];
                var sqrDist = (t.position - targetPosition).sqrMagnitude;
                if (sqrDist < closestSqrDistance)
                {
                    closestSqrDistance = sqrDist;
                    closestIndex = index;
                }
            }

            return closestIndex;
        }

        public static int GetClosestIndex(this Transform[] points, Vector3 targetPosition)
        {
            return points.ToList().GetClosestIndex(targetPosition);
        }

        public static void ClearParent(this Transform target)
        {
            target.SetParent(null);
        }

        public static void DestroyAllChildren(this Transform target)
        {
            while (target.childCount > 0)
            {
                Object.DestroyImmediate(target.GetChild(0).gameObject);
            }
        }

        public static void ResetLocalTransform(this Transform target)
        {
            ResetScale(target);
            ResetLocalPositionRotation(target);
        }

        public static void ResetLocalPositionRotation(this Transform target)
        {
            ResetLocalRotation(target);
            ResetLocalPosition(target);
        }

        public static void ResetScale(this Transform target)
        {
            target.localScale = Vector3.one;
        }

        public static void ResetLocalRotation(this Transform target)
        {
            target.localRotation = Quaternion.identity;
        }

        public static void ResetLocalPosition(this Transform target)
        {
            target.localPosition = Vector3.zero;
        }

        public static float AngleTo(this Transform source, Transform target)
        {
            var pivot = source.position + source.rotation * Vector3.up;
            var faceDirLocal = Quaternion.Inverse(source.rotation) * (target.position - pivot);
            var angle = Mathf.Atan2(faceDirLocal.x, faceDirLocal.z) * Mathf.Rad2Deg;
            return angle;
        }
    }
}