using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.Entity
{
    [Serializable]
    public class SVFoot : SVSerializable
    {
        [SerializeField] [Required] private SARVIdentifier footIdentifier;

        [SerializeField] [Required] private Transform footTransform;

        private string GroupTitle => footTransform.gameObject.name;
        public SARVIdentifier FootIdentifier => footIdentifier;
        public Transform FootTransform => footTransform;
    }
}