using System;
using System.Collections;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Reflection;
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
        private string property = "";

        [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [ShowIf(nameof(IsPropertyHasValue))]
        private SVPropertyComponent<string> propertyComponent = new SVNullProperty<string>();

        private bool IsPropertyHasValue => !string.IsNullOrEmpty(property);
        private bool IsPropertyComponentNull => propertyComponent == null || string.IsNullOrEmpty(propertyComponent.Value);
        public override string Value => IsPropertyComponentNull ? string.Empty : propertyComponent.Value;

        public override string ToString()
        {
            return propertyComponent.ToString();
        }

        private void OnPropertyChanged()
        {
            if (string.IsNullOrEmpty(property))
            {
                propertyComponent = new SVNullProperty<string>();
                return;
            }

            var selectedComponent = SVReflection.GetPropertyTypeByTitle<string>(property);
            if (selectedComponent == null || selectedComponent == propertyComponent.GetType())
            {
                return;
            }

            propertyComponent = Activator.CreateInstance(selectedComponent) as SVPropertyComponent<string>;
        }

        private IEnumerable GetAllStringProperties()
        {
            var componentTitles = SVReflection.GetPropertyTitlesByType<string>();
            return componentTitles;
        }
    }
}