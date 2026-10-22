using __SARV.Framework.Integration.Animancer.Parameter.Type;
using __SARV.Framework.Module.Footstep;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerFootstep : SVSubPlayerInput
    {
        [FoldoutGroup("Footstep")] [BoxGroup("Footstep/Event")] [SerializeField] [HideLabel] [Required]
        private StringAsset footstepEvent;

        [FoldoutGroup("Footstep")] [SerializeField] [HideLabel]
        private SVFootstep footstep;

        public SVFootstep Footstep => footstep;

        protected override void Awake()
        {
            base.Awake();
            Footstep.HandleAwake();
        }

        protected override void Start()
        {
            base.Start();
            AnimancerComponent.Events.AddTo<SVFootstepParameterType>(footstepEvent, HandleFootstepEventHandler);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            AnimancerComponent.Events.Remove(footstepEvent);
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Footstep.HandleOnDrawGizmos();
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Footstep.HandleOnDrawGizmosSelected();
        }

        private void HandleFootstepEventHandler(SVFootstepParameterType parameter)
        {
            Footstep.HandleFootstep(parameter.FootIdentifier, parameter.FootStateIdentifier);
        }
    }
}