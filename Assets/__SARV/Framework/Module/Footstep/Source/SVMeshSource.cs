using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Footstep.Entity;
using __SARV.Framework.Module.Footstep.Source.Base;
using __SARV.Framework.Module.Raycast.Entity;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.Source
{
    [SVTitle("Mesh")]
    [SVDescription("Determines footstep effects based on the mesh material at the character's position")]
    public class SVMeshSource : SVFootstepSource
    {
        public override SVSurface GetSurfaceAt(Vector3 position, SVRaycastResult result)
        {
            return null;
        }
    }
}