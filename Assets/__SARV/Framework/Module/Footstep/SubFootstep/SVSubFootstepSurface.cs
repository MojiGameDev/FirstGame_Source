using System;
using System.Collections.Generic;
using __SARV.Framework.Module.Footstep.Entity;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepSurface : SVSubFootstepFeet
    {
        [BoxGroup("Surface")] [SerializeField] [Required]
        private SARVSurfaceDatabase surfaceDatabase;
        
        protected Dictionary<SARVIdentifier, SVSurface> RuntimeSurfaces = new();

        public override void HandleAwake()
        {
            base.HandleAwake();
            foreach (var surface in surfaceDatabase.Surfaces)
            {
                RuntimeSurfaces.Add(surface.FootStateIdentifier, surface);
            }
        }
    }
}