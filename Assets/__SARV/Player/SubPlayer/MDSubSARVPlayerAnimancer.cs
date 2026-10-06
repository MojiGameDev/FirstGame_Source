using __SARV.Wrapper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class MDSubSARVPlayerAnimancer : SVSubSARVPlayerReference
    {
        [FoldoutGroup("Animancer")] [SerializeField] [HideLabel]
        private SVAnimancerWrapper animancerWrapper;

        public SVAnimancerWrapper SubAnimancerWrapper => animancerWrapper;

        protected override void Start()
        {
            base.Start();
            SubAnimancerWrapper.SetAnimancerComponent(AnimancerComponent);
        }
    }
}