using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Component;
using __SARV.Core.Extension;
using __SARV.Core.Reflection;
using __SARV.Framework.Behavior;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Base
{
    public abstract class SVBaseState : SVMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel]
        protected string description = "";

        [BoxGroup("$" + nameof(BehaviorTitle), showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllBehaviorComponents))] [OnValueChanged(nameof(OnBehaviorChanged), InvokeOnInitialize = true)]
        protected string behavior = "";

        [BoxGroup("$" + nameof(BehaviorTitle), showLabel: false)] [BoxGroup("$" + nameof(BehaviorTitle) + "/InnerRow01", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsBehaviorComponentNull))] [OnValueChanged(nameof(OnBehaviorComponentChanged), includeChildren: true)]
        protected SVBehaviorComponent behaviorComponent = new SVNullBehavior();

        public SVBehaviorComponent Behavior => IsBehaviorComponentNull ? null : behaviorComponent;
        public bool IsBehaviorComponentNull => behaviorComponent is SVNullBehavior or null;
        public string BehaviorTitle => $"{(IsBehaviorComponentNull ? "..." : behaviorComponent.GetType().GetTitle())}";

        protected abstract List<string> GetAllBehaviorComponentPaths();
        protected abstract Type GetBehaviorComponentByPath(string behaviorName);

        private IEnumerable GetAllBehaviorComponents()
        {
            var components = GetAllBehaviorComponentPaths();
            return components.Select(d => new ValueDropdownItem(d, d));
        }

        private void OnBehaviorChanged()
        {
            if (string.IsNullOrEmpty(behavior))
            {
                behaviorComponent = new SVNullBehavior();
                return;
            }

            var selectedComponent = GetBehaviorComponentByPath(behavior);
            if (selectedComponent == null || selectedComponent == behaviorComponent.GetType())
            {
                return;
            }

            behaviorComponent = (SVBehaviorComponent)Activator.CreateInstance(selectedComponent);
        }

        private void OnBehaviorComponentChanged()
        {
            Debug.Log("ChildOrSelf Changed");
        }
    }
}