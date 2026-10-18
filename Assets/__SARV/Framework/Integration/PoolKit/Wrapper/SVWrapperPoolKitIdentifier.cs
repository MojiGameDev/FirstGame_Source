using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using UnityEngine;

namespace __SARV.Framework.Integration.PoolKit.Wrapper
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