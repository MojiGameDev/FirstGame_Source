using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.State.Behavior.Agent.Base;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior.Agent
{
    [SVTitle("Idle")]
    [SVCategory(SVConstantCategory.Behavior.AGENT)]
    [SVDescription("Keeps the agent idle without performing any movement or actions")]
    [Serializable]
    public class SVAgentBehaviorIdle : SVAgentBehavior
    {
        [BoxGroup("Animancer")] [SerializeField] [Required]
        private StringAsset transitionAlias;

        public override async Task Enter()
        {
            await base.Enter();
            Actor.PlayAnimancer(transitionAlias, footIk: true);
        }
    }
}