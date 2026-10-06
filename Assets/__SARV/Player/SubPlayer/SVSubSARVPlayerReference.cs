using __SARV.Core.Base;
using Animancer;
using ECM2;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected Character character;

        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        private AnimancerComponent animancerComponent;

        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
        public AnimancerComponent AnimancerComponent => animancerComponent;
    }
}