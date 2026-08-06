using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace __MD.Script.Core.Extension
{
    public static class MDGameObjectExtension
    {
        public static void Hide(this GameObject target)
        {
            if (target.activeSelf)
            {
                target.SetActive(false);
            }
        }

        public static void Show(this GameObject target)
        {
            if (!target.activeSelf)
            {
                target.SetActive(true);
            }
        }

        public static void ClearParent(this GameObject target)
        {
            target.SetParent(null);
        }

        public static void SetParent(this GameObject target, Transform parent, bool worldPositionStays = false)
        {
            target.transform.SetParent(parent, worldPositionStays);
        }

        public static void ResetLocalTransform(this GameObject target)
        {
            target.transform.ResetScale();
            ResetLocalPositionRotation(target);
        }

        public static void ResetLocalPositionRotation(this GameObject target)
        {
            target.transform.ResetLocalRotation();
            target.transform.ResetLocalPosition();
        }

        public static void DestroyAllChildren(this GameObject target)
        {
            target.transform.DestroyAllChildren();
        }

        public static List<Transform> GetAllBones(this GameObject target)
        {
            var skinnedMesh = target.GetComponentInChildren<SkinnedMeshRenderer>();

            if (skinnedMesh != null)
            {
                // This works for Humans, Creatures, Quadrupeds, etc.
                return skinnedMesh.bones.ToList();
            }

            Debug.LogWarning("No SkinnedMeshRenderer found. Falling back to hierarchy search.");
            return null;
        }
    }
}