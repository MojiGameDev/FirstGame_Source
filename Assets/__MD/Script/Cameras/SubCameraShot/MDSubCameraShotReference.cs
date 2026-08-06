using __MD.Script.Core.Base;
using __MD.Script.Core.Extension;
using __MD.Script.Identifier;
using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace __MD.Script.Cameras.SubCameraShot
{
    [RequireComponent(typeof(CinemachineCamera))]
    public abstract class MDSubCameraShotReference : MDOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [Required]
        protected MDIdentifier identifier;

        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required]
        protected CinemachineCamera cinemachineCamera;

        private GameObject _shakePivot;

        public MDIdentifier Identifier => identifier;
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