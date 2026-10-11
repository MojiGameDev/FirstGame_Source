using __SARV.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Cameras.SubCamera
{
    public abstract class SVSubSARVCameraReference : SARV
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected Camera mainCamera;

        public Camera MainCamera => mainCamera;
    }
}