using System;
using System.Collections;
using System.Linq;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Reflection;
using __SARV.Framework.Property.Null;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Property
{
    [SVTitle("String")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Includes all properties that are composed of strings")]
    [SVIgnore]
    [Serializable]
    public class SVStringProperty : SVPropertyComponent<string>
    {
        [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllStringProperties))] [OnValueChanged(nameof(OnPropertyChanged))]
        private string property;

        [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [ShowIf(nameof(IsPropertyHasValue))]
        private SVPropertyComponent<string> propertyComponent = new SVNullProperty<string>();

        private bool IsPropertyHasValue => string.IsNullOrEmpty(property);
        private bool IsPropertyComponentNull => !string.IsNullOrEmpty(propertyComponent.Value);
        public override string Value => IsPropertyComponentNull ? null : propertyComponent.Value;

        private void OnPropertyChanged()
        {
            if (string.IsNullOrEmpty(property))
            {
                propertyComponent = new SVNullProperty<string>();
                return;
            }

            var selectedComponent = SVReflection.GetPropertyTypeByPath<string>(property);

            if (selectedComponent != null && selectedComponent == propertyComponent)
            {
                return;
            }

            propertyComponent = selectedComponent;
        }

        private IEnumerable GetAllStringProperties()
        {
            var components = SVReflection.GetAllTriggerComponents();
            return components.Select(d => new ValueDropdownItem(d, d));
        }
    }
}