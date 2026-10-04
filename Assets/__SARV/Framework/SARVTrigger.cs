using System;
using System.Collections;
using System.Linq;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Extension;
using __SARV.Core.Reflection;
using __SARV.Framework.Signal;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVTrigger : SVInstructionMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";

        [BoxGroup("$" + nameof(SignalTitle), showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllSignalComponents))] [Required] [OnValueChanged(nameof(OnSignalChanged), InvokeOnInitialize = true)]
        private string signal = "";

        [BoxGroup("$" + nameof(SignalTitle), showLabel: false)] [BoxGroup("$" + nameof(SignalTitle) + "/InnerRow01", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsSignalComponentNull))] [OnValueChanged(nameof(OnSignalComponentChanged), includeChildren: true)]
        private SVSignalComponent signalComponent = new SVNullSignal();

        [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Execute the following instructions when the event above is raised", InfoMessageType.Info)]
        private string tooltip = "";

        public SVSignalComponent SignalComponent => IsSignalComponentNull ? null : signalComponent;
        public bool IsSignalComponentNull => signalComponent is SVNullSignal or null;
        public string SignalTitle => $"{(IsSignalComponentNull ? "..." : signalComponent.GetType().GetTitle())}";

        private void Awake()
        {
            SignalComponent?.HandleAwake();
        }

        private void Start()
        {
            SignalComponent?.HandleStart();
        }

        private void OnEnable()
        {
            SignalComponent?.HandleOnEnable();
        }

        private void Update()
        {
            SignalComponent?.HandleUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            SignalComponent?.HandleFixedUpdate(Time.deltaTime);
        }

        private void OnDisable()
        {
            SignalComponent?.HandleOnDisable();
        }

        private void OnDestroy()
        {
            SignalComponent?.HandleOnDestroy();
        }

        private void OnTriggerEnter(Collider other)
        {
            SignalComponent?.HandleOnTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            SignalComponent?.HandleOnTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            SignalComponent?.HandleOnTriggerExit(other);
        }

        private IEnumerable GetAllSignalComponents()
        {
            var components = SVReflection.GetAllSignalComponentPaths();
            return components.Select(d => new ValueDropdownItem(d, d));
        }

        private void OnSignalChanged()
        {
            if (string.IsNullOrEmpty(signal))
            {
                signalComponent = new SVNullSignal();
                return;
            }

            var selectedComponent = SVReflection.GetSignalByPath(signal);

            if (selectedComponent == null || selectedComponent == signalComponent.GetType())
            {
                return;
            }

            signalComponent = (SVSignalComponent)Activator.CreateInstance(selectedComponent);
        }

        private void OnSignalComponentChanged()
        {
            Debug.Log("ChildOrSelf Changed");
        }
    }
}