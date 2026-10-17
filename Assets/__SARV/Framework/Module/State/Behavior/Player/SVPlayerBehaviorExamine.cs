using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.State.Behavior.Base;

namespace __SARV.Framework.Module.State.Behavior
{
    [SVTitle("Examine")]
    [SVCategory(SVConstantCategory.Behavior.EXAMINE)]
    [SVDescription("Allows the player to examine the environment and interact with points of interest")]
    [Serializable]
    public class SVPlayerBehaviorExamine : SVPlayerBehavior
    {
        public override async Task Enter()
        {
            await base.Enter();
            Player.Animancer.Play(Identifier);
        }
    }
}