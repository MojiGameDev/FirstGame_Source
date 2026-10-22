using System;
using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Footstep.Entity;
using __SARV.Framework.Module.Raycast.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.Source.Base
{
    [Serializable]
    public abstract class SVFootstepSource : SVSerializableLifeCycle
    {
        [BoxGroup("Surfaces", showLabel: false)] [SerializeField] [RequiredListLength(1, 15)]
        private List<SVSurface> surfaces = new();

        public abstract SVSurface GetSurfaceAt(Vector3 position, SVRaycastResult result);
    }
}