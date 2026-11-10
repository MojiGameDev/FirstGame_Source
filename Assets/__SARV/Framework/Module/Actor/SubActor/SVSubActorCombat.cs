using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Actor.Entity;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Melee;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorCombat : SVSubActorRagdoll
    {
        public SARVIdentifier AttackBehaviorIdentifier { get; protected set; }
        public SARVMeleeWeapon CurrentMeleeWeapon { get; protected set; }
        public SARVMeleeShield CurrentMeleeShield { get; protected set; }
        public SVHitResult CurrentHitResult { get; protected set; }

        protected Dictionary<SVEquipmentKey, GameObject> RuntimeEquipmentItem = new();

        public void SetAttackBehaviorIdentifier(SARVIdentifier identifier)
        {
            AttackBehaviorIdentifier = identifier;
        }

        public void SetHitResult(SVHitResult hitResult)
        {
            CurrentHitResult = hitResult;
        }

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

        public void AttachEquipment(GameObject equipment, SVBone bone, Vector3 position, Vector3 rotation)
        {
            var boneTransform = bone.GetTransform(animancerComponent.Animator);
            var combatItemKey = new SVEquipmentKey(equipment, boneTransform);
            if (!RuntimeEquipmentItem.TryGetValue(combatItemKey, out var equipmentInstance))
            {
                equipmentInstance = Instantiate(equipment);
                RuntimeEquipmentItem.Add(combatItemKey, equipmentInstance);
            }

            equipmentInstance.transform.parent = boneTransform;
            equipmentInstance.transform.localPosition = position;
            equipmentInstance.transform.localRotation = Quaternion.Euler(rotation);
            equipmentInstance.Active();
        }
    }
}