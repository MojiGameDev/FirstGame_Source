using __SARV.Common.Base;
using __SARV.Framework.Module.Localizer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMelee
{
    public abstract class SVSubMeleeInfo : SVScriptableObject
    {
        [FoldoutGroup("Info")] [SerializeField] [Required]
        protected SARVLocalizer title;

        [FoldoutGroup("Info")] [SerializeField]
        protected SARVLocalizer description;
    }
}