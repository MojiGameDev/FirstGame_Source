using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using UnityEngine;

namespace __SARV.Framework.Integration.MasterAudio.Wrapper
{
    [Serializable]
    public class SVWrapperMasterAudioIdentifier : SVSerializable
    {
        [SerializeField] private SARVIdentifier identifier;
        [SerializeField] private string clipName;

        public SARVIdentifier Identifier => identifier;
        public string ClipName => clipName;
    }
}