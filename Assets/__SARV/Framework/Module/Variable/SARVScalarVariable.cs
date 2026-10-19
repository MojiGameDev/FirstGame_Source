using System.Collections.Generic;
using System.Linq;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Module.Variable.Base;
using __SARV.Framework.Module.Variable.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable
{
    public class SARVScalarVariable : SVKernal
    {
        [BoxGroup("Row01", showLabel: false)] [HorizontalGroup("Row01/Group01")] [SerializeField] [HideLabel]
        private string title = "";

        [BoxGroup("Row01", showLabel: false)]
        [HorizontalGroup("Row01/Group01", Width = 21)]
        [HideLabel]
        [Button(ButtonSizes.Medium, Icon = SdfIconType.Plus, ButtonHeight = 21)]
        [EnableIf(nameof(IsVariableTitleValid))]
        private void AddNewVariable()
        {
            if (IsVariableTitleValid)
            {
                var variable = new SVLocalVariable();
                variable.SetTitle(title);
                variables.Add(variable);
                title = "";
            }
        }

        private bool IsVariableTitleValid => !string.IsNullOrEmpty(title);

        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnVariablesChanged))]
        private List<SVLocalVariable> variables = new();

        public void SetValue(string variableName, object value)
        {
            var selectedVariable = variables.First(d => d.Title == variableName);
            selectedVariable.VariableValue.Value = value;
        }

        public List<string> GetAllNamesByValueType<TType>() where TType : SVVariableValue
        {
            var variableNames = variables
                .Where(d => d.VariableValue.GetType() == typeof(TType))
                .Select(d => d.Title)
                .ToList();
            return variableNames;
        }

        private void OnVariablesChanged()
        {
        }
    }
}