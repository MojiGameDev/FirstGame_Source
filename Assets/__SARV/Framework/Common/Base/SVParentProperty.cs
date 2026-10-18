using System;
using System.Collections;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Base
{
    [Serializable]
    public class SVParentProperty<TType> : SVPropertyComponent<TType>
    {
        [SerializeField] [SVLabel] [ValueDropdown(nameof(GetAllProperties))] [OnValueChanged(nameof(OnPropertyChanged))]
        protected string property = "";

        [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [ShowIf(nameof(IsPropertyHasValue))]
        protected SVPropertyComponent<TType> propertyType = new SVNullProperty<TType>();

        protected bool IsPropertyHasValue => !string.IsNullOrEmpty(property);
        protected bool IsPropertyComponentNull => propertyType is null or SVNullProperty<TType>;

        public override TType GetValue(SVArgument argument)
        {
            return IsPropertyComponentNull ? default : propertyType.GetValue(argument);
        }

        private void OnPropertyChanged()
        {
            if (string.IsNullOrEmpty(property))
            {
                propertyType = new SVNullProperty<TType>();
                return;
            }

            var selectedComponent = SVReflection.GetPropertyTypeByTitle<TType>(property);
            if (selectedComponent == null || selectedComponent == propertyType.GetType())
            {
                return;
            }

            propertyType = Activator.CreateInstance(selectedComponent) as SVPropertyComponent<TType>;
        }

        private IEnumerable GetAllProperties()
        {
            var componentTitles = SVReflection.GetPropertyTitlesByType<TType>();
            return componentTitles;
        }
    }
}