using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Integration.PoolKit.Wrapper
{
    [Serializable]
    public class SVWrapperPoolKitIdentifier : SVSerializable
    {
        [SerializeField] [Required] private SARVIdentifier identifier;
        [SerializeField] [Required] private Transform target;

        public SARVIdentifier Identifier => identifier;
        public Transform Target => target;
    }
}