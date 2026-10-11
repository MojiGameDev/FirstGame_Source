using System.Collections.Generic;
using System.Linq;
using __SARV.Cameras.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Cameras.SubCamera
{
    public abstract class SVSubSARVCameraShot : SVSubSARVCameraReference
    {
        [FoldoutGroup("Shot")] [SerializeField] [RequiredListLength(1, 10)]
        protected List<SVCameraShot> cameraShots = new();

        public List<SVCameraShot> CameraShots => cameraShots;

        protected override void Start()
        {
            base.Start();
            CameraShots.First().CameraShot.Priority = int.MaxValue;
        }
    }
}