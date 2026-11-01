using System;
using System.Threading.Tasks;
using __SARV.Framework.Module.Melee;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorEquipment : SVSubActorAnimancer
    {
        public async Task EquipMeleeWeapon(SARVMeleeWeapon meleeWeapon)
        {
            CurrentMeleeWeapon = meleeWeapon;
            await CurrentMeleeWeapon.ExecuteEquip(Argument);
        }
        public async Task EquipMeleeShield(SARVMeleeShield meleeShield)
        {
            CurrentMeleeShield = meleeShield;
            await CurrentMeleeShield.ExecuteEquip(Argument);
        }

        public async Task UnequipMeleeWeapon()
        {
            await CurrentMeleeWeapon.ExecuteUnequip(Argument);
        }

        public async Task UnequipMeleeShield()
        {
            await CurrentMeleeShield.ExecuteUnequip(Argument);
        }
    }
}