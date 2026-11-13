using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace __SARV.Framework.Module.Cameras.SubCameraShot
{
    public abstract class SVSubCameraShotReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected SARVIdentifier identifier;

        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required]
        protected CinemachineCamera cinemachineCamera;

        private GameObject _shakePivot;

        public SARVIdentifier Identifier => identifier;
        public CinemachineCamera CinemachineCamera => cinemachineCamera;
        public Transform ShakePivotTransform => _shakePivot.transform;

        protected override void Awake()
        {
            base.Awake();
            HandleAddShakePivot();
        }

        private void HandleAddShakePivot()
        {
            _shakePivot = new GameObject($"ShakePivot-{gameObject.name}");
            transform.parent = ShakePivotTransform;
        }
    }
}