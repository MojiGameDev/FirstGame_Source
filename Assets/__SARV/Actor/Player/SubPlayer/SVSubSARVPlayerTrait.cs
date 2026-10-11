using __SARV.Trait;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Player.SubPlayer
{
    public abstract class SVSubSARVPlayerTrait : SVSubSARVPlayerStateMachine
    {
        [FoldoutGroup("Trait")] [BoxGroup("Trait/Attribute")] [TabGroup("Trait/Attribute/Attribute", "Health")] [SerializeField] [Required] [HideLabel] [HideReferenceObjectPicker]
        private SVAttribute healthAttribute;

        [FoldoutGroup("Trait")] [BoxGroup("Trait/Attribute")] [TabGroup("Trait/Attribute/Attribute", "Stamina")] [SerializeField] [Required] [HideLabel] [HideReferenceObjectPicker]
        private SVAttribute staminaAttribute;
    }
}