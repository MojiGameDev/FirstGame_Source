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

        [BoxGroup("$" + nameof(SignalTitle), showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllSignalComponents))] [OnValueChanged(nameof(OnSignalChanged), InvokeOnInitialize = true)]
        private string signal = "";

        [BoxGroup("$" + nameof(SignalTitle), showLabel: false)] [BoxGroup("$" + nameof(SignalTitle) + "/InnerRow01", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsSignalComponentNull))] [OnValueChanged(nameof(OnSignalComponentChanged), includeChildren: true)]
        private SVSignalComponent signalComponent = new SVNullSignal();

        [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Execute the following instructions when the event above is raised")]
        private string tooltip = "";

        public SVSignalComponent Signal => IsSignalComponentNull ? null : signalComponent;
        public bool IsSignalComponentNull => signalComponent is SVNullSignal or null;
        public string SignalTitle => $"{(IsSignalComponentNull ? "..." : signalComponent.GetType().GetTitle())}";

        private void Awake()
        {
            signalComponent.SetHandler(d=>_ = ExecuteInstructions(d));
            Signal.HandleAwake();
        }

        private void Start()
        {
            Signal.HandleStart();
        }

        private void OnEnable()
        {
            Signal.HandleOnEnable();
        }

        private void Update()
        {
            Signal.HandleUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            Signal.HandleFixedUpdate(Time.fixedDeltaTime);
        }

        private void OnDisable()
        {
            Signal.HandleOnDisable();
        }

        private void OnDestroy()
        {
            Signal.HandleOnDestroy();
        }

        private void OnTriggerEnter(Collider other)
        {
            Signal.HandleOnTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            Signal.HandleOnTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Signal.HandleOnTriggerExit(other);
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