using __SARV.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Cameras.SubCamera
{
    public abstract class SubSARVCameraReference : SARV
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        private Camera mainCamera;

        public Camera MainCamera => mainCamera;
    }
}