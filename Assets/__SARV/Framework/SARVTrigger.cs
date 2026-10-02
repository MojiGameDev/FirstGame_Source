using __MD.Script.Core.Base;
using __SARV.Core.Extension;
using __SARV.Framework.Extension;
using __SARV.Framework.Logic;
using __SARV.Framework.Trigger;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVTrigger : MDMonoBehaviour
    {
        [BoxGroup("$TriggerTitle", showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown("_triggerCategories")] [Required] [OnValueChanged(nameof(OnTriggerChanged), InvokeOnInitialize = true)]
        private string trigger = "";

        [BoxGroup("$TriggerTitle", showLabel: false)] [BoxGroup("$TriggerTitle/Row02", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsTriggerLogicNull))] [OnValueChanged(nameof(OnTriggerComponentChanged))]
        private SVTriggerComponent triggerComponent = new SVNullTrigger();

        public SVTriggerComponent TriggerComponent => triggerComponent;
        public bool IsTriggerLogicNull => TriggerComponent is SVNullTrigger or null;
        public string TriggerTitle => $"{(IsTriggerLogicNull ? "..." : triggerComponent.GetTitle())}";

        private void OnTriggerChanged()
        {
            if (string.IsNullOrEmpty(trigger))
            {
                triggerComponent = new SVNullTrigger();
                return;
            }
        }

        private void OnTriggerComponentChanged()
        {
        }
    }
}