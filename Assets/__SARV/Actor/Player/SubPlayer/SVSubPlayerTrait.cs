using __SARV.Framework.Module.Trait;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerTrait : SVSubPlayerStateMachine
    {
        [FoldoutGroup("Trait")] [BoxGroup("Trait/Attribute")] [TabGroup("Trait/Attribute/Attribute", "Health")] [SerializeField] [Required] [HideLabel] [HideReferenceObjectPicker]
        private SVAttribute healthAttribute;

        [FoldoutGroup("Trait")] [BoxGroup("Trait/Attribute")] [TabGroup("Trait/Attribute/Attribute", "Stamina")] [SerializeField] [Required] [HideLabel] [HideReferenceObjectPicker]
        private SVAttribute staminaAttribute;
    }
}