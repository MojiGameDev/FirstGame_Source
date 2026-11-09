using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeWeapon
{
    public abstract class SVSubMeleeWeaponCombo : SVSubMeleeShieldHandling
    {
        [FoldoutGroup("Combo")] [SerializeField] [Required]
        protected SARVMeleeCombo meleeCombo;
        
        public SARVMeleeCombo MeleeCombo => meleeCombo;
    }
}