using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.State.Behavior.Base;

namespace __SARV.Framework.Module.State.Behavior
{
    [SVTitle("MeleeAttack")]
    [SVCategory(SVConstantCategory.Behavior.PLAYER)]
    [SVDescription("Handles the player's melee attack behavior")]
    [Serializable]
    public class SVPlayerBehaviorMeleeAttack : SVPlayerBehavior
    {
        public override async Task Enter()
        {
            await base.Enter();
        }

        public override void Tick(float deltaTime)
        {
            
        }

        public override async Task Exit()
        {
            await base.Exit();
        }
    }
}