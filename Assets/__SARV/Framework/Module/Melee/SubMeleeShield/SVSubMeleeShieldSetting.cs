using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeShield
{
    public abstract class SVSubMeleeShieldSetting : SVScriptableObject
    {
        [FoldoutGroup("Setting")] [SerializeField] [Required]
        private SARVIdentifier identifier;
    }
}