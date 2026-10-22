using System;
using __SARV.Framework.Module.Identifier;
using UnityEngine;

namespace __SARV.Framework.Integration.Animancer.Parameter.Type
{
    [Serializable]
    public struct SVFootstepParameterType
    {
        [SerializeField] private SARVIdentifier footIdentifier;
        [SerializeField] private SARVIdentifier footStateIdentifier;

        public SARVIdentifier FootIdentifier => footIdentifier;
        public SARVIdentifier FootStateIdentifier => footStateIdentifier;
    }
}