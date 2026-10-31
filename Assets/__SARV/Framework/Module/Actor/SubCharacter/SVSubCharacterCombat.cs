using System;
using __SARV.Actor.Player.SubPlayer;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Module.Melee;

namespace __SARV.Framework.Module.Actor.SubCharacter
{
    [Serializable]
    public abstract class SVSubCharacterCombat : SVSubCharacterData
    {
        public void Equip(SVActor actor, SARVMelee melee)
        {
            CurrentMelee = melee;
            _ = CurrentMelee.ExecuteEquip(SVArgument.Create(actor.gameObject));
        }

        public void Unequip(SVActor actor)
        {
            _ = CurrentMelee.ExecuteEquip(SVArgument.Create(actor.gameObject));
        }
    }
}