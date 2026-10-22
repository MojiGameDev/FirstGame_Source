using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Module.Footstep.Entity;
using __SARV.Framework.Module.Footstep.Source.Base;
using __SARV.Framework.Module.Raycast.Entity;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.Source
{
    [SVTitle("Trigger")]
    [SVDescription("Overrides footstep effects when a character enters a trigger")]
    public class SVTriggerSource : SVFootstepSource
    {
        public override SVSurface GetSurfaceAt(Vector3 position, SVRaycastResult result)
        {
            return null;
        }
    }
}