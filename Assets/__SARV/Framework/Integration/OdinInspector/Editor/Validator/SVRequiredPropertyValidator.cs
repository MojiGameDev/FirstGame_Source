using __SARV.Common.Extension;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using UnityEngine;
using Sirenix.OdinInspector.Editor.Validation;
using __SARV.Framework.Integration.OdinInspector.Editor.Validator;

[assembly: RegisterValidator(typeof(SVRequiredPropertyValidator))]

namespace __SARV.Framework.Integration.OdinInspector.Editor.Validator
{
    public sealed class SVRequiredPropertyValidator : AttributeValidator<SVRequiredAttribute>
    {
        protected override void Validate(ValidationResult result)
        {
            var obj = Property.ValueEntry.WeakSmartValue;

            if (!HasValidValue(obj))
            {
                var fieldName = Property.Name;
                var displayName = string.IsNullOrEmpty(fieldName) ? "Value" : char.ToUpperInvariant(fieldName[0]) + fieldName[1..];
                result.AddError($"{displayName} is required");
            }
        }

        private static bool HasValidValue(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();

            // An unconfigured property is invalid.
            if (type.IsNullProperty())
            {
                return false;
            }

            // Parent properties contain another property.
            var propertyTypeField = type.GetFieldInHierarchy("propertyType");

            if (propertyTypeField != null)
            {
                var nestedProperty = propertyTypeField.GetValue(obj);
                return HasValidValue(nestedProperty);
            }

            // We have reached a terminal property.
            // Only concrete properties with a "value" field are checked here.
            var valueField = type.GetFieldInHierarchy("value");

            if (valueField == null)
            {
                //UnityEngine.Debug.LogWarning($"SVRequired: No 'value' field found on terminal property {type.FullName}.");
                return true;
            }

            var value = valueField.GetValue(obj);

            if (value is Object unityObject)
            {
                return unityObject != null;
            }

            if (value is string)
            {
                return !string.IsNullOrEmpty(value.ToString());
            }
            
            return value != null;
        }
    }
}