using __SARV.Core.Base;
using __SARV.Core.Shared;
using Animancer;
using ECM2;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        private Character character;

        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected AnimancerComponent animancerComponent;

        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
        public Character Character => character;
    }
}