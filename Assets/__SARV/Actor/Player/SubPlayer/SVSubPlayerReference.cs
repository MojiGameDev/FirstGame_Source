using __SARV.Common.Base;
using __SARV.Framework;
using __SARV.Framework.Module.State;
using Animancer;
using ECM2;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerReference : SVOverrideMonoBehaviour
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        private Character character;

        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        private AnimancerComponent animancerComponent;

        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
        public AnimancerComponent AnimancerComponent => animancerComponent;
        public Character Character => character;
    }
}