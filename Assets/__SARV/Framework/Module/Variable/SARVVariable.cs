using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Module.Variable.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    public class SARVVariable : SVKernal
    {
        [BoxGroup("Row01", showLabel: false)] [HorizontalGroup("Row01/Group01")] [SerializeField] [HideLabel]
        private string title = "";

        [BoxGroup("Row01", showLabel: false)] [HorizontalGroup("Row01/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllVariableTypes))]
        private string type = "";

        [BoxGroup("Row01", showLabel: false)]
        [HorizontalGroup("Row01/Group01", Width = 21)]
        [HideLabel]
        [Button(ButtonSizes.Medium, Icon = SdfIconType.Plus, ButtonHeight = 21)]
        [EnableIf(nameof(IsCreateVariableFormValid))]
        private void AddNewVariable()
        {
            if (IsCreateVariableFormValid)
            {
                var variableType = SVReflection.GetVariableTypeByPath(type);
                var variableInstance = (SVVariable)Activator.CreateInstance(variableType);
                variableInstance.SetTitle(title);
                variables.Add(variableInstance);
                title = "";
                type = "";
            }
        }

        private bool IsCreateVariableFormValid => !string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(type);

        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnVariablesChanged))]
        private List<SVVariable> variables = new();

        public void SetValue(string variableName, object value)
        {
            var selectedVariable = variables.First(d => d.Title == variableName);
            selectedVariable.Value = value;
        }

        public T GetValue<T>(string variableName)
        {
            var selectedVariable = variables.First(d => d.Title == variableName);
            return (T)selectedVariable.Value;
        }

        public List<string> GetAllNamesByValueType<TType>() where TType : SVVariable
        {
            var variableNames = variables
                .Where(d => d.GetType() == typeof(TType))
                .Select(d => d.Title)
                .ToList();
            return variableNames;
        }

        private void OnVariablesChanged()
        {
        }

        private IEnumerable GetAllVariableTypes()
        {
            var variableTypes = SVReflection.GetAllVariableTypes();
            return variableTypes.Select(d => new ValueDropdownItem(d, d));
        }
    }
}