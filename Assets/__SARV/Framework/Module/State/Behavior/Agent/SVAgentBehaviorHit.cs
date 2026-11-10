using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Reaction;
using __SARV.Framework.Module.State.Behavior.Agent.Base;
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
        [BoxGroup("Reaction")] [SerializeField] [Required] [HideLabel]
        private SARVReaction reaction;

        public override async Task Enter()
        {
            await base.Enter();
            Debug.Log(Actor.CurrentHitResult.HitPosition);
        }
    }
}