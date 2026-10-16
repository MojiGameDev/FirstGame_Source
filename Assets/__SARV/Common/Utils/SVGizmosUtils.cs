using __SARV.Common.Extension;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace __SARV.Common.Utils
{
    public static class SVGizmosUtils
    {
        public static void DrawCircle(Transform transform, Vector3 centerPosition, float circleRadius, Color color)
        {
            var center = transform.TransformPoint(centerPosition);
            var radius = circleRadius * Mathf.Max(
                transform.lossyScale.x,
                transform.lossyScale.y,
                transform.lossyScale.z
            );

#if UNITY_EDITOR
            Handles.color = color;
            Handles.DrawSolidDisc(center, Vector3.up, radius);

            Handles.color = Color.black;
            Handles.DrawWireDisc(center, Vector3.up, radius);
#endif
        }

        public static void DrawArch(Transform startPoint, float halfAngle, float pointRadius, Color pointColor, float archRange, Color archColor)
        {
            var origin = startPoint.position;
            var forward = startPoint.forward;

            forward.y = 0f;

            if (!forward.sqrMagnitude.HasValue())
            {
                return;
            }

            forward.Normalize();
            var left = Quaternion.AngleAxis(-halfAngle, Vector3.up) * forward;

            var right = Quaternion.AngleAxis(halfAngle, Vector3.up) * forward;

            Gizmos.color = pointColor;
            Gizmos.DrawSphere(origin, pointRadius);

            Gizmos.color = Color.black;
            Gizmos.DrawRay(origin, forward * archRange);
            Gizmos.DrawRay(origin, left * archRange);
            Gizmos.DrawRay(origin, right * archRange);

#if UNITY_EDITOR
            Handles.color = archColor;

            Handles.DrawSolidArc(
                origin,
                Vector3.up,
                left,
                halfAngle * 2f,
                archRange);
#endif
        }
    }
}