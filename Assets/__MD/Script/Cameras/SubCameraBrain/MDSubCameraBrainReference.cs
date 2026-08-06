using __MD.Script.Core.Base;
using __MD.Script.Core.Extension;
using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace __MD.Script.Cameras.SubCameraBrain
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(CinemachineBrain))]
    public abstract class MDSubCameraBrainReference : MDOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected Camera mainCamera;

        protected override void Awake()
        {
            base.Awake();
            gameObject.ClearParent();
        }
    }
}