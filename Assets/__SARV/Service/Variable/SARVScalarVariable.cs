using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Variable.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable
{
    public class SARVScalarVariable : SVMonoBehaviour
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
                var variable = new SVVariable();
                variable.SetTitle(title);
                variables.Add(variable);
                title = "";
            }
        }

        private bool IsVariableTitleValid => !string.IsNullOrEmpty(title);

        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnVariablesChanged))]
        private List<SVVariable> variables = new();

        private void OnVariablesChanged()
        {
        }
    }
}