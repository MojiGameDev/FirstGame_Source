using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeWeapon
{
    public abstract class SVSubMeleeWeaponSetting : SVScriptableObject
    {
        [FoldoutGroup("Setting")] [SerializeField] [Required]
        private SARVIdentifier identifier;
    }
}