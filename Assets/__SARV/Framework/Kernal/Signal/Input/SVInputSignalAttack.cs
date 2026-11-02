using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Actor.Access;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("Attack")]
    [SVCategory(SVConstantCategory.Signal.INPUT)]
    [SVDescription("Executes the trigger while the player is pressing the attack input")]
    [Serializable]
    public class SVInputSignalAttack : SVSignalComponent
    {
        public override void HandleUpdate(SARVTrigger trigger)
        {
            if (SVAccessPlayer.Instance.InputAttack)
            {
                trigger.Execute();
            }
        }
    }
}