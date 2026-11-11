using System;
using System.Collections.Generic;
using __SARV.Framework.Module.Hurtpoint;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorHurtpoint : SVSubActorData
    {
        [FoldoutGroup("Hurtpoint")] [SerializeField] [Required]
        protected List<SARVHurtpoint> hurtpoints = new();

        [FoldoutGroup("Hurtpoint")]
        [Button]
        private void DetectHurtpoints()
        {
            hurtpoints.Clear();
            foreach (var hurtpoint in puppetMaster.GetComponentsInChildren<SARVHurtpoint>(true))
            {
                hurtpoints.Add(hurtpoint);
            }
        }

        protected SARVHurtpoint GetClosestHurtpoint(Vector3 hitPosition)
        {
            SARVHurtpoint closestHurtpoint = null;
            var closestDistance = float.MaxValue;

            foreach (var candidate in hurtpoints)
            {
                if (candidate == null)
                {
                    continue;
                }

                var distance = (candidate.transform.position - hitPosition).sqrMagnitude;

                if (distance >= closestDistance)
                {
                    continue;
                }

                closestDistance = distance;
                closestHurtpoint = candidate;
            }

            return closestHurtpoint;
        }
    }
}