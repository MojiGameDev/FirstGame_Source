using System;
using System.Collections;
using System.Linq;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Extension;
using __SARV.Core.Reflection;
using __SARV.Framework.Behavior;
using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVState : SVMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";
        
        [BoxGroup("$" + nameof(BehaviorTitle), showLabel: false)] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllBehaviorComponents))] [Required] [OnValueChanged(nameof(OnBehaviorChanged), InvokeOnInitialize = true)]
        private string behavior = "";

        [BoxGroup("$" + nameof(BehaviorTitle), showLabel: false)] [BoxGroup("$" + nameof(BehaviorTitle) + "/InnerRow01", showLabel: false)] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [HideIf(nameof(IsBehaviorComponentNull))] [OnValueChanged(nameof(OnBehaviorComponentChanged), includeChildren: true)]
        private SVBehaviorComponent behaviorComponent = new SVNullBehavior();
        
        public SVBehaviorComponent BehaviorComponent => IsBehaviorComponentNull ? null : behaviorComponent;
        public bool IsBehaviorComponentNull => behaviorComponent is SVNullBehavior or null;
        public string BehaviorTitle => $"{(IsBehaviorComponentNull ? "..." : behaviorComponent.GetType().GetTitle())}";

        private IEnumerable GetAllBehaviorComponents()
        {
            var components = SVReflection.GetAllBehaviorComponentPaths();
            return components.Select(d => new ValueDropdownItem(d, d));
        }

        private void OnBehaviorChanged()
        {
            if (string.IsNullOrEmpty(behavior))
            {
                behaviorComponent = new SVNullBehavior();
                return;
            }

            var selectedComponent = SVReflection.GetBehaviorByPath(behavior);

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