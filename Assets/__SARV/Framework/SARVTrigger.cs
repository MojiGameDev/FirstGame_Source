using System;
using System.Collections;
using System.Linq;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Extension;
using __SARV.Core.Reflection;
using __SARV.Framework.Trigger;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVTrigger : SVMonoBehaviour
    {
        [BoxGroup("$TriggerTitle", showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllTriggerComponents))] [Required] [OnValueChanged(nameof(OnTriggerChanged), InvokeOnInitialize = true)]
        private string trigger = "";

        [BoxGroup("$TriggerTitle", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";

        [BoxGroup("$TriggerTitle", showLabel: false)] [BoxGroup("$TriggerTitle/Row02", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsTriggerComponentNull))] [OnValueChanged(nameof(OnTriggerComponentChanged), includeChildren: true)]
        private SVTriggerComponent triggerComponent = new SVNullTrigger();

        public SVTriggerComponent TriggerComponent => IsTriggerComponentNull ? null : triggerComponent;
        public bool IsTriggerComponentNull => triggerComponent is SVNullTrigger or null;
        public string TriggerTitle => $"{(IsTriggerComponentNull ? "..." : triggerComponent.GetTitle())}";

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