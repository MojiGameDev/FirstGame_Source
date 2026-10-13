using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace __SARV.Framework.Module.Cameras.Entity
{
    [Serializable]
    public class SVCameraShot : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("Identifier")] [HideLabel] [Required]
        private SARVIdentifier identifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Title("Camera")] [HideLabel] [Required]
        private CinemachineCamera cameraShot;

        public SARVIdentifier Identifier => identifier;
        public CinemachineCamera CameraShot => cameraShot;
        private string GroupTitle => Identifier == null ? "Shot" : Identifier.name;
    }
}