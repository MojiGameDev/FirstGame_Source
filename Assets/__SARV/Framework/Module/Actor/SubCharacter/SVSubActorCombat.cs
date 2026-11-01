using System;
using __SARV.Framework.Module.Melee;

namespace __SARV.Framework.Module.Actor.SubCharacter
{
    [Serializable]
    public abstract class SVSubActorCombat : SVSubActorAnimancer
    {
        public void Equip(SARVMelee melee)
        {
            CurrentMelee = melee;
            _ = CurrentMelee.ExecuteEquip(Argument);
        }

        public void Unequip()
        {
            _ = CurrentMelee.ExecuteEquip(Argument);
        }
    }
}