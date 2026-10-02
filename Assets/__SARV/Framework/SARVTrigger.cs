using System;
using System.Collections;
using System.Linq;
using __MD.Script.Core.Base;
using __SARV.Core.Extension;
using __SARV.Core.Reflection;
using __SARV.Framework.Component;
using __SARV.Framework.Trigger;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVTrigger : MDMonoBehaviour
    {
        [BoxGroup("$TriggerTitle", showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllTriggerComponents))] [Required] [OnValueChanged(nameof(OnTriggerChanged), InvokeOnInitialize = true)]
        private string trigger = "";

        [BoxGroup("$TriggerTitle", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";

        [BoxGroup("$TriggerTitle", showLabel: false)] [BoxGroup("$TriggerTitle/Row02", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsTriggerLogicNull))] [OnValueChanged(nameof(OnTriggerComponentChanged), includeChildren: true)]
        private SVTriggerComponent triggerComponent = new SVNullTrigger();

        public SVTriggerComponent TriggerComponent => IsTriggerLogicNull ? null : triggerComponent;
        public bool IsTriggerLogicNull => triggerComponent is SVNullTrigger or null;
        public string TriggerTitle => $"{(IsTriggerLogicNull ? "..." : triggerComponent.GetTitle())}";

        private void Awake()
        {
            TriggerComponent?.HandleAwake();
        }

        private void Start()
        {
            TriggerComponent?.HandleStart();
        }

        private void OnEnable()
        {
            TriggerComponent?.HandleOnEnable();
        }

        private void Update()
        {
            TriggerComponent?.HandleUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            TriggerComponent?.HandleFixedUpdate(Time.deltaTime);
        }

        private void OnDisable()
        {
            TriggerComponent?.HandleOnDisable();
        }

        private void OnDestroy()
        {
            TriggerComponent?.HandleOnDestroy();
        }

        private void OnTriggerEnter(Collider other)
        {
            TriggerComponent?.HandleOnTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerComponent?.HandleOnTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerComponent?.HandleOnTriggerExit(other);
        }

        private IEnumerable GetAllTriggerComponents()
        {
            var components = SVReflection.GetAllTriggerComponents();
            return components.Select(d => new ValueDropdownItem(d, d));
        }

        private void OnTriggerChanged()
        {
            if (string.IsNullOrEmpty(trigger))
            {
                triggerComponent = new SVNullTrigger();
                return;
            }

            var selectedComponent = SVReflection.GetTriggerByPath(trigger);

            if (selectedComponent != null && selectedComponent == triggerComponent)
            {
                return;
            }

            triggerComponent = selectedComponent;
        }

        private void OnTriggerComponentChanged()
        {
            Debug.Log("ChildOrSelf Changed");
        }
    }
}