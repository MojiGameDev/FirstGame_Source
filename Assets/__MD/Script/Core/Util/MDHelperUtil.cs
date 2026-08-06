using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace __MD.Script.Core.Util
{
    public static class MDHelperUtil
    {
        public static bool GetRandomBool()
        {
            return Random.value > 0.5f;
        }

        public static string NewId()
        {
            return Guid.NewGuid().ToString("N");
        }
        
        public static Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t,float bezierTension)
        {
            return 0.5f * (
                (2f * p1) +
                (-p0 + p2) * t +
                (2f * p0 - 5f * p1 + 4f * p2 - p3) * t * t +
                (-p0 + 3f * p1 - 3f * p2 + p3) * t * t * t
            ) * (2f - bezierTension);
        }
    }
}