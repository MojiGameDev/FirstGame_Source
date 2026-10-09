using System;
using System.Collections;
using __SARV.Core.Component;
using __SARV.Core.Reflection;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Base
{
    [Serializable]
    public abstract class SVParentProperty<TType> : SVPropertyComponent<TType>
    {
        [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllProperties))] [OnValueChanged(nameof(OnPropertyChanged))]
        protected string property = "";

        [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [ShowIf(nameof(IsPropertyHasValue))]
        protected SVPropertyComponent<TType> propertyComponent = new SVNullProperty<TType>();

        protected bool IsPropertyHasValue => !string.IsNullOrEmpty(property);
        protected bool IsPropertyComponentNull => propertyComponent is null or SVNullProperty<TType>;
        public override TType Value => IsPropertyComponentNull ? default : propertyComponent.Value;

        private void OnPropertyChanged()
        {
            if (string.IsNullOrEmpty(property))
            {
                propertyComponent = new SVNullProperty<TType>();
                return;
            }

            var selectedComponent = SVReflection.GetPropertyTypeByTitle<TType>(property);
            if (selectedComponent == null || selectedComponent == propertyComponent.GetType())
            {
                return;
            }

            propertyComponent = Activator.CreateInstance(selectedComponent) as SVPropertyComponent<TType>;
        }

        private IEnumerable GetAllProperties()
        {
            var componentTitles = SVReflection.GetPropertyTitlesByType<TType>();
            return componentTitles;
        }
    }
}