using System.Collections.Generic;
using System.Linq;
using __SARV.Framework.Module.Cameras.Entity;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace __SARV.Framework.Module.Cameras.SubCamera
{
    public abstract class SVSubCameraShot : SVSubCameraReference
    {
        [FoldoutGroup("Shot")] [SerializeField] [RequiredListLength(1, 10)]
        protected List<SVCameraShot> cameraShots = new();

        protected readonly Dictionary<SARVIdentifier, SVCameraShot> RuntimeCameraShot = new();
        
        protected SVCameraShot CurrentCameraShot;

        protected override void Awake()
        {
            base.Awake();
            HandleCameraShotsToDictionary();
        }

        protected override void Start()
        {
            base.Start();
            HandleDefaultCameraShot();
        }

        private void HandleDefaultCameraShot()
        {
            foreach (var cameraShot in RuntimeCameraShot)
            {
                cameraShot.Value.CinemachineCamera.Priority = -1;
            }

            var defaultCameraShotIdentifier = cameraShots.First().Identifier;
            CurrentCameraShot = RuntimeCameraShot[defaultCameraShotIdentifier];
            CurrentCameraShot.CinemachineCamera.Priority = int.MaxValue;
        }

        private void HandleCameraShotsToDictionary()
        {
            foreach (var cameraShot in cameraShots)
            {
                RuntimeCameraShot.Add(cameraShot.Identifier, cameraShot);
            }
        }
    }
}