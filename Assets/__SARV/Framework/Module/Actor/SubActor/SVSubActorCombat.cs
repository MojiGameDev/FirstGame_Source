using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Actor.Entity;
using __SARV.Framework.Module.Hitbox.Entity;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Melee;
using __SARV.Framework.Module.Reaction.Enum;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorCombat : SVSubActorHurtpoint
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
        
        public SVReactionDirection GetCurrentHitDirectionAsEnum()
        {
            // Reverse weapon travel direction.
            var incomingDirection = -CurrentHitResult.HitDirection;

            // Convert to actor-local direction.
            var localDirection = transform.InverseTransformDirection(incomingDirection);

            // Find the dominant axis.
            var absDirection = new Vector3(
                Mathf.Abs(localDirection.x),
                Mathf.Abs(localDirection.y),
                Mathf.Abs(localDirection.z)
            );

            if (absDirection.y > absDirection.x && absDirection.y > absDirection.z)
            {
                return localDirection.y > 0f ? SVReactionDirection.Top : SVReactionDirection.Bottom;
            }

            if (absDirection.z > absDirection.x)
            {
                return localDirection.z > 0f ? SVReactionDirection.Front : SVReactionDirection.Back;
            }

            return localDirection.x > 0f ? SVReactionDirection.Right : SVReactionDirection.Left;
        }
    }
}