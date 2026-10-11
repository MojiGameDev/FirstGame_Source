using __SARV.Framework.Module.State;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Cameras.SubCamera
{
    public abstract class SVSubSARVCameraReference : SARV
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected Camera mainCamera;

        public Camera MainCamera => mainCamera;
    }
}