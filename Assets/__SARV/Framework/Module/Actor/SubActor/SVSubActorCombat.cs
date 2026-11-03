using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Identifier;
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

        public SARVMeleeWeapon CurrentMeleeWeapon { get; protected set; }
        public SVCombatType CurrentCombatType => currentCombatType;

        protected Dictionary<SARVIdentifier, GameObject> EquipmentCache = new();

        public void SetCombatType(SVCombatType combatType)
        {
            currentCombatType = combatType;
        }

        public async Task EquipMeleeWeapon(SARVMeleeWeapon meleeWeapon)
        {
            CurrentMeleeWeapon = meleeWeapon;
            await CurrentMeleeWeapon.ExecuteEquip(Argument);
        }

        public async Task UnequipMeleeWeapon()
        {
            await CurrentMeleeWeapon.ExecuteUnequip(Argument);
        }

        public void AttachEquipment(SARVIdentifier identifier, SVBone bone, Vector3 position, Vector3 rotation)
        {
            if (EquipmentCache.TryGetValue(identifier, out var instance))
            {
                var boneTransform = bone.GetTransform(animancerComponent.Animator);
                instance.transform.parent = boneTransform;
                instance.transform.localPosition = position;
                instance.transform.localRotation = Quaternion.Euler(rotation);
                instance.Active();
            }
        }

        private void HandleEquipmentCache(SARVIdentifier identifier, GameObject model)
        {
            if (!EquipmentCache.ContainsKey(identifier))
            {
                var instance = Instantiate(model);
                instance.Inactive();
            }
        }
    }
}