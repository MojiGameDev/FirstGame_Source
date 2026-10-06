using __SARV.Core.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerAnimancer : SVSubSARVPlayerInput
    {
        [FoldoutGroup("Animancer")] [SerializeField] [HideLabel]
        private SVSharedAnimancer sharedAnimancer;

        public SVSharedAnimancer SharedAnimancer => sharedAnimancer;

        protected override void Awake()
        {
            base.Awake();
            SharedAnimancer.HandleAwake();
        }

        protected override void Start()
        {
            base.Start();
            SharedAnimancer.SetAnimancerComponent(AnimancerComponent);
        }
    }
}