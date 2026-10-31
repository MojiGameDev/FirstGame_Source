using __SARV.Framework.Module.Actor;
using Animancer;
using ECM2;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerReference : SVActor
    {
        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected Character ecmCharacter;

        [FoldoutGroup("Reference")] [SerializeField] [SceneObjectsOnly] [Required] [HideLabel]
        protected AnimancerComponent animancerComponent;

        public AnimancerComponent AnimancerComponent => animancerComponent;
        public Character ECMCharacter => ecmCharacter;
    }
}