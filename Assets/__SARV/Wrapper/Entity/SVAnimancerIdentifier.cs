using System;
using __SARV.Core.Base;
using __SARV.Identifier;
using Animancer;
using UnityEngine;

namespace __SARV.Wrapper.Entity
{
    [Serializable]
    public class SVAnimancerIdentifier : SVSerializable
    {
        [SerializeField] private SVIdentifier identifier;
        [SerializeField] private StringAsset alias;

        public SVIdentifier Identifier => identifier;
        public StringAsset Alias => alias;
    }
}