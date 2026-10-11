using System;
using __SARV.Core.Base;
using __SARV.Identifier;
using Animancer;
using UnityEngine;

namespace __SARV.Core.Wrapper
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