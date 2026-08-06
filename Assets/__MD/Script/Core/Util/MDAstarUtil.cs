using Pathfinding;
using UnityEngine;

namespace __MD.Script.Core.Util
{
    public static class MDAstarUtil
    {
        private static readonly NearestNodeConstraint NearestWalkableConstraint = NearestNodeConstraint.Walkable;
        
        public static NNInfo GetNearestPoint(Vector3 targetPosition)
        {
            var nearest = AstarPath.active.GetNearest(targetPosition, NearestWalkableConstraint);
            return nearest;
        }

        public static NNInfo GetNearestPoint(Transform target)
        {
            return GetNearestPoint(target.position);
        }
    }
}