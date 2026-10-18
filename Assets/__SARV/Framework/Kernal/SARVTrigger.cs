using System;
using System.Collections;
using System.Linq;
using __SARV.Common.Base;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Common.Shared;
using __SARV.Framework.Kernal.Signal;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal
{
    public class SARVTrigger : SVKernal
    {
        [BoxGroup("$" + nameof(SignalTitle), showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllSignalComponents))] [OnValueChanged(nameof(OnSignalChanged), InvokeOnInitialize = true)]
        private string signal = "";

        [BoxGroup("$" + nameof(SignalTitle), showLabel: false)] [BoxGroup("$" + nameof(SignalTitle) + "/InnerRow01", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsSignalComponentNull))] [OnValueChanged(nameof(OnSignalComponentChanged), includeChildren: true)]
        private SVSignalComponent signalComponent = new SVNullSignal();

        [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Execute the following instructions when the event above is raised")]
        private string tooltip = "";

        [SerializeField] [HideLabel] private SVInstruction instruction;

        public SVSignalComponent Signal => IsSignalComponentNull ? null : signalComponent;
        public bool IsSignalComponentNull => signalComponent is SVNullSignal or null;
        public string SignalTitle => $"{(IsSignalComponentNull ? "..." : signalComponent.GetType().GetTitle())}";

        protected override void Awake()
        {
            Signal.HandleAwake(this);
        }

        protected override void Start()
        {
            Signal.HandleStart(this);
        }

        protected override void OnEnable()
        {
            Signal.HandleOnEnable(this);
        }

        protected override void Update()
        {
            Signal.HandleUpdate(this);
        }

        protected override void FixedUpdate()
        {
            Signal.HandleFixedUpdate(this);
        }

        protected override void OnDisable()
        {
            Signal.HandleOnDisable(this);
        }

        protected override void OnDestroy()
        {
            Signal.HandleOnDestroy(this);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            Signal.HandleOnTriggerEnter(this, other);
        }

        protected override void OnTriggerStay(Collider other)
        {
            Signal.HandleOnTriggerStay(this, other);
        }

        protected override void OnTriggerExit(Collider other)
        {
            Signal.HandleOnTriggerExit(this, other);
        }

        public void Execute()
        {
            _ = instruction.ExecuteInstructions(SVArgument.Create(gameObject));
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
        }
    }
}