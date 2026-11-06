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

        public static void DrawRaycastGuide(Vector3 position, float radius, float distance, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(position, position + Vector3.down * distance);
            Gizmos.DrawSphere(position, radius);
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

        public static void DrawCube(Vector3 position, Quaternion rotation, Vector3 size, Color color)
        {
            Gizmos.color = color;

            Gizmos.matrix = Matrix4x4.TRS(
                position,
                rotation,
                Vector3.one
            );

            Gizmos.DrawCube(Vector3.zero, size);
        }

        public static void DrawBox(BoxCollider box, Color color)
        {
            Gizmos.color = color;
            var oldMatrix = Gizmos.matrix;

            Gizmos.matrix = box.transform.localToWorldMatrix;
            Gizmos.DrawCube(box.center, box.size);

            Gizmos.matrix = oldMatrix;
        }

        public static void DrawSphere(SphereCollider sphere, Color color)
        {
            Gizmos.color = color;
            var oldMatrix = Gizmos.matrix;

            Gizmos.matrix = sphere.transform.localToWorldMatrix;
            Gizmos.DrawSphere(sphere.center, sphere.radius);

            Gizmos.matrix = oldMatrix;
        }

        public static void DrawCapsule(CapsuleCollider capsule, Color color)
        {
            Gizmos.color = color;
            var t = capsule.transform;

            var center = t.TransformPoint(capsule.center);
            var scale = t.lossyScale;

            var axis = capsule.direction;

            var direction = axis switch
            {
                0 => t.right,
                1 => t.up,
                _ => t.forward
            };

            var radiusScale = axis switch
            {
                0 => Mathf.Max(scale.y, scale.z),
                1 => Mathf.Max(scale.x, scale.z),
                _ => Mathf.Max(scale.x, scale.y)
            };

            var radius = capsule.radius * radiusScale;
            var height = Mathf.Max(
                capsule.height * Mathf.Abs(scale[axis]),
                radius * 2f
            );

            var halfSegment = (height - radius * 2f) * 0.5f;

            Gizmos.DrawSphere(center + direction * halfSegment, radius);
            Gizmos.DrawSphere(center - direction * halfSegment, radius);

            var size = Vector3.one * radius * 2f;
            size[axis] = height - radius * 2f;

            var oldMatrix = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(center, t.rotation, Vector3.one);

            Gizmos.DrawCube(Vector3.zero, size);

            Gizmos.matrix = oldMatrix;
        }

        public static void DrawCollider(Collider collider, Color color)
        {
            switch (collider)
            {
                case BoxCollider box:
                    DrawBox(box, color);
                    break;

                case SphereCollider sphere:
                    DrawSphere(sphere, color);
                    break;

                case CapsuleCollider capsule:
                    DrawCapsule(capsule, color);
                    break;
            }
        }
    }
}