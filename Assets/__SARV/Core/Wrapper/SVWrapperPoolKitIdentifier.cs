using System;
using __SARV.Core.Base;
using __SARV.Identifier;
using UnityEngine;

namespace __SARV.Core.Wrapper
{
    [Serializable]
    public class SVWrapperPoolKitIdentifier : SVSerializable
    {
        [SerializeField] private SARVIdentifier identifier;
        [SerializeField] private Transform target;

        public SARVIdentifier Identifier => identifier;
        public Transform Target => target;
    }
}