using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.Animancer.Enum;
using __SARV.Framework.Integration.Animancer.Parameter.Type;
using __SARV.Framework.Module.Reaction;
using __SARV.Framework.Module.State.Behavior.Agent.Base;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior.Agent
{
    [SVTitle("Hit")]
    [SVCategory(SVConstantCategory.Behavior.AGENT)]
    [SVDescription("Handles the agent's hit reaction")]
    [Serializable]
    public class SVAgentBehaviorHit : SVAgentBehavior
    {
        [BoxGroup("Animancer")] [SerializeField] [Required]
        private StringAsset animationEvent;

        [BoxGroup("Reaction")] [SerializeField] [Required] [HideLabel]
        private SARVReaction reaction;

        public override async Task Enter()
        {
            await base.Enter();
            Actor.AnimancerComponent.Events.AddTo<SVAnimationParameterType>(animationEvent, HandleAnimationEventHandler);
            Actor.HandleAgentRootMotionMovement();
            var hitReaction = reaction.GetReaction(Actor.CurrentHitResult.Power, Actor.CurrentHitResult.GetDirectionAsEnum());
            Actor.PlayAnimancer(hitReaction.Alias, footIk: true, restart: true);
            Actor.ApplyRagdollHit();
        }

        public override async Task Exit()
        {
            Actor.HandleAgentTransformBasedMovement();
            Actor.HandleAgentDestination(Actor.Position);
            await base.Exit();
        }

        private void HandleAnimationEventHandler(SVAnimationParameterType parameter)
        {
            if (parameter.AnimationPhase == SVMAnimationPhase.End)
            {
                Debug.Log("End");
            }
        }
    }
}