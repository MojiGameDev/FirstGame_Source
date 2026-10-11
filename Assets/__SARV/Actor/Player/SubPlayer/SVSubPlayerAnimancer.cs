using __SARV.Actor.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerAnimancer : SVSubPlayerInput
    {
        [FoldoutGroup("Animancer")] [SerializeField] [HideLabel]
        private SVAnimancer animancer;

        public SVAnimancer Animancer => animancer;

        protected override void Awake()
        {
            base.Awake();
            Animancer.HandleAwake();
        }

        protected override void Start()
        {
            base.Start();
            Animancer.SetAnimancerComponent(AnimancerComponent);
        }
    }
}