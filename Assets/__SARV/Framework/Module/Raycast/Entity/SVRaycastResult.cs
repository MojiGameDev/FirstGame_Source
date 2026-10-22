using UnityEngine;

namespace __SARV.Framework.Module.Raycast.Entity
{
    public class SVRaycastResult
    {
        public Transform Transform { get; private set; }
        public Vector3 Point { get; private set; }
        public Vector3 Normal { get; private set; }
        public int TriangleIndex { get; private set; }
        public Vector2 TextureCoord { get; private set; }

        public SVRaycastResult(Transform transform, Vector3 point, Vector3 normal, int triangleIndex, Vector2 textureCoord)
        {
            Transform = transform;
            Point = point;
            Normal = normal;
            TriangleIndex = triangleIndex;
            TextureCoord = textureCoord;
        }
    }
}