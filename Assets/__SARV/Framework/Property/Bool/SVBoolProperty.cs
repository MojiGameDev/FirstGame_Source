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
    [SVCategory(SVConstantCategory.Property.BOOL)]
    [SVDescription("Includes all properties that are composed of booleans")]
    [SVIgnore]
    [Serializable]
    public class SVBoolProperty : SVPropertyComponent<bool>
    {
        [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllBoolProperties))] [OnValueChanged(nameof(OnPropertyChanged))]
        private string property = "";

        [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [ShowIf(nameof(IsPropertyHasValue))]
        private SVPropertyComponent<bool> propertyComponent = new SVNullProperty<bool>();

        private bool IsPropertyHasValue => !string.IsNullOrEmpty(property);
        private bool IsPropertyComponentNull => propertyComponent == null;
        public override bool Value => IsPropertyComponentNull ? false : propertyComponent.Value;

        private void OnPropertyChanged()
        {
            if (string.IsNullOrEmpty(property))
            {
                propertyComponent = new SVNullProperty<bool>();
                return;
            }

            var selectedComponent = SVReflection.GetPropertyTypeByTitle<bool>(property);
            if (selectedComponent == null || selectedComponent == propertyComponent.GetType())
            {
                return;
            }

            propertyComponent = Activator.CreateInstance(selectedComponent) as SVPropertyComponent<bool>;
        }

        private IEnumerable GetAllBoolProperties()
        {
            var componentTitles = SVReflection.GetPropertyTitlesByType<bool>();
            return componentTitles;
        }
    }
}