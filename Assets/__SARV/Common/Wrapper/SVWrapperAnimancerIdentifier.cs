using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Animancer;
using UnityEngine;

namespace __SARV.Common.Wrapper
{
    [Serializable]
    public class SVWrapperAnimancerIdentifier : SVSerializable
    {
        [SerializeField] private SARVIdentifier identifier;
        [SerializeField] private StringAsset alias;

        public SARVIdentifier Identifier => identifier;
        public StringAsset Alias => alias;
    }
}