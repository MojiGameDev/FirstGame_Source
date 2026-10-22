using System;
using __SARV.Framework.Integration.Animancer.Parameter.Type;
using __SARV.Framework.Module.Identifier;
using __SARV.SceneControl.Game;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepManager : SVSubFootstepDetection
    {
        private static readonly int BASE_MAP_TEXTURE_ID = Shader.PropertyToID("_BaseMap");

        public void HandleFootstep(SARVIdentifier footIdentifier, SARVIdentifier footStateIdentifier)
        {
            var foot = RuntimeFeet[footIdentifier];

            if (IsFootGrounded(foot.FootTransform, out var raycastResult))
            {
                var footstepSource = raycastResult.Transform.GetComponent<SARVFootstepSource>();
                if (footstepSource != null)
                {
                    var texture = footstepSource.GetTextureAt(raycastResult);
                    var effectIdentifier = RuntimeSurfaces[texture].EffectIdentifier;
                    SARVGame.Instance.SpawnInPool(effectIdentifier, raycastResult.Point);
                }
                else
                {
                    Debug.Log("Footstep Source Not Found => " + raycastResult.Transform.name);
                }
            }
        }
    }
}