using System;
using __SARV.Framework.Module.Melee;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorEquipment : SVSubActorAnimancer
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