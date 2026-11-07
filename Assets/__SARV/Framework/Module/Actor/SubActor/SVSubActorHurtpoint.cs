using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorHurtpoint : SVSubActorData
    {
        [FoldoutGroup("Hurtpoint")] [SerializeField] [Required]
        private List<SARVHurtpoint> hurtpoints =  new();
        
        public SARVHurtpoint GetClosestHurtpoint(Vector3 hitPosition)
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