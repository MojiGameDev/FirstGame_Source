using System;
using __SARV.Framework.Module.Identifier;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepPlay : SVSubFootstepSurface
    {
        private static readonly int BASE_MAP_TEXTURE_ID = Shader.PropertyToID("_BaseMap");
        
        public void PlayFootstep(RaycastHit hit, SARVIdentifier footStateIdentifier)
        {
            var surface = RuntimeSurfaces[footStateIdentifier];
        }
    }
}