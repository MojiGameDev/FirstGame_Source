using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepDetection : SVSubFootstepPlay
    {
        [BoxGroup("Detection")] [SerializeField] [PropertyRange(0.1f, 1f)]
        protected float raycastDistance = 0.5f;
    }
}