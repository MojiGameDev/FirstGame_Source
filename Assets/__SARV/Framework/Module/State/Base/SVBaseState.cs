using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Common.Base;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Module.State.Behavior;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Base
{
    public abstract class SVBaseState : SVMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel] [OnValueChanged(nameof(OnDescriptionChanged), InvokeOnInitialize = true)]
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

        private const string UNKNOWN_STATE_NAME = "Unknown State";

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

            OnDescriptionChanged();
            behaviorComponent = (SVBehaviorComponent)Activator.CreateInstance(selectedComponent);
        }

        private void OnBehaviorComponentChanged()
        {
            Debug.Log("ChildOrSelf Changed");
        }

        private void OnDescriptionChanged()
        {
            if (!string.IsNullOrEmpty(description) && description.Equals(UNKNOWN_STATE_NAME) && !string.IsNullOrEmpty(behavior))
            {
                description = behavior;
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                if (string.IsNullOrEmpty(behavior))
                {
                    gameObject.name = description = UNKNOWN_STATE_NAME;
                    return;
                }

                gameObject.name = description = behavior;
                return;
            }

            gameObject.name = description;
        }
    }
}