using System.Collections.Generic;
using __MD.Script.Core.Extension;
using __MD.Script.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.Cameras.SubCameraBrain
{
    public abstract class MDSubCameraBrainShot : MDSubCameraBrainReference
    {
        [FoldoutGroup("Shot")] [SerializeField] [RequiredListLength(1, 100)]
        protected List<MDCameraShot> cameraShots = new();

        protected readonly Dictionary<MDIdentifier, MDCameraShot> CameraShotLookup = new();

        protected override void Awake()
        {
            base.Awake();
            HandleBuildCameraShotLookup();
        }

        private void HandleBuildCameraShotLookup()
        {
            foreach (var cameraShot in cameraShots)
            {
                CameraShotLookup.Add(cameraShot.Identifier, cameraShot);
            }
        }
    }
}