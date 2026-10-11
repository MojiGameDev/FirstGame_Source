using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Cameras.SubCamera
{
    public abstract class SVSubCameraReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected Camera mainCamera;

        public Camera MainCamera => mainCamera;
    }
}