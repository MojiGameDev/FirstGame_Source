using System;
using __SARV.Framework.Integration.Animancer.Parameter.Type;
using __SARV.Framework.Module.Identifier;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepManager : SVSubFootstepDetection
    {
        public void HandleFootstep(SARVIdentifier footIdentifier, SARVIdentifier footStateIdentifier)
        {
            var foot = RuntimeFeet[footIdentifier];
            if (IsFootGrounded(foot.FootTransform, out var hit))
            {
                PlayFootstep(hit, footStateIdentifier);
            }
        }
    }
}