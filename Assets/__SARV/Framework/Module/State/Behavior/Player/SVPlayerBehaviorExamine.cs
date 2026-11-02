using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.State.Behavior.Base;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior
{
    [SVTitle("Examine")]
    [SVCategory(SVConstantCategory.Behavior.EXAMINE)]
    [SVDescription("Allows the player to examine the environment and interact with points of interest")]
    [Serializable]
    public class SVPlayerBehaviorExamine : SVPlayerInteractBehavior
    {
        [BoxGroup("Animancer")] [SerializeField] [Required]
        private StringAsset transitionAlias;

        public override async Task Enter()
        {
            await base.Enter();
            Player.PlayAnimancer(transitionAlias);
        }
    }
}