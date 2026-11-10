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
            foreach (var hurtpoint in GetComponentsInChildren<SARVHurtpoint>(true))
            {
                hurtpoints.Add(hurtpoint);
            }
        }
    }
}