using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Melee;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorCombat : SVSubActorData
    {
        [FoldoutGroup("Data")] [SerializeField] [ReadOnly]
        protected SVCombatType currentCombatType = SVCombatType.None;

        public SARVMeleeAttack CurrentMeleeAttack { get; protected set; }
        public SARVMeleeWeapon CurrentMeleeWeapon { get; protected set; }
        public SARVMeleeShield CurrentMeleeShield { get; protected set; }
        public SVCombatType CurrentCombatType => currentCombatType;

        protected Dictionary<SVEquipmentType, GameObject> EquipmentCache = new();

        public void SetCombatType(SVCombatType combatType)
        {
            currentCombatType = combatType;
        }

        public void SetMeleeAttack(SARVMeleeAttack meleeAttack)
        {
            CurrentMeleeAttack = meleeAttack;
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

        public void AttachEquipment(SVEquipmentType equipmentType, GameObject prop, SVBone bone, Vector3 position, Vector3 rotation)
        {
            if (!EquipmentCache.ContainsKey(equipmentType))
            {
                var boneTransform = bone.GetTransform(animancerComponent.Animator);
                var instance = Instantiate(prop, boneTransform, true);
                instance.transform.localPosition = position;
                instance.transform.localRotation = Quaternion.Euler(rotation);
                EquipmentCache.Add(equipmentType, instance);
            }

            var equipmentObject = EquipmentCache[equipmentType];
            equipmentObject.Active();
        }
    }
}