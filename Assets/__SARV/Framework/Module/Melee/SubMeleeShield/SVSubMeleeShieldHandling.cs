using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeShield
{
    public abstract class SVSubMeleeShieldHandling : SVSubMeleeShieldEquipment
    {
        [FoldoutGroup("Handling")] [SerializeField] [Title("OnEquip")] [HideLabel]
        private SVInstruction onEquipInstruction;

        [FoldoutGroup("Handling")] [SerializeField] [Title("OnUnequip")] [HideLabel]
        private SVInstruction onUnequipInstruction;

        [FoldoutGroup("Handling")] [SerializeField] [Title("OnHolster")] [HideLabel]
        private SVInstruction onHolsterInstruction;

        public async Task ExecuteEquip(SVArgument argument)
        {
            await onEquipInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteUnequip(SVArgument argument)
        {
            await onUnequipInstruction.ExecuteInstructions(argument);
        }

        public async Task ExecuteHolster(SVArgument argument)
        {
            await onHolsterInstruction.ExecuteInstructions(argument);
        }
    }
}