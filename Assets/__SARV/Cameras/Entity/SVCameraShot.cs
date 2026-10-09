using System;
using __SARV.Core.Base;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace __SARV.Cameras.Entity
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