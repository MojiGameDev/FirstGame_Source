using System;
using __SARV.Framework.Module.Footstep.Enum;
using __SARV.Framework.Module.Raycast.Entity;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstepSource
{
    public abstract class SubFootstepSourceManager : SubFootstepSourceTerrain
    {
        public Texture GetTextureAt(SVRaycastResult result)
        {
            switch (type)
            {
                case SVFootstepSourceType.Terrain:
                    return GetTerrainTextureAt(result.Point);
                    break;
                case SVFootstepSourceType.Mesh:
                    break;
            }
            return null;
        }
    }
}