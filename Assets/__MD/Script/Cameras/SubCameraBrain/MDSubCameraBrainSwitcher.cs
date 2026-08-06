using __MD.Script.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.Cameras.SubCameraBrain
{
    public abstract class MDSubCameraBrainSwitcher : MDSubCameraBrainShot
    {
        [FoldoutGroup("Switcher")] [SerializeField] [Required]
        protected MDIdentifier defaultCameraShotIdentifier;

        protected MDCameraShot CurrentCameraShot;

        protected override void Start()
        {
            base.Start();
            HandleDefaultCameraShot();
        }

        private void HandleDefaultCameraShot()
        {
            foreach (var cameraShot in CameraShotLookup)
            {
                cameraShot.Value.CinemachineCamera.Priority = -1;
            }

            CurrentCameraShot = CameraShotLookup[defaultCameraShotIdentifier];
            CurrentCameraShot.CinemachineCamera.Priority = int.MaxValue;
        }
    }
}