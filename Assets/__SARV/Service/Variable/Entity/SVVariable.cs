using System;
using System.Collections;
using __SARV.Core.Base;
using __SARV.Core.Reflection;
using __SARV.Identifier;
using __SARV.Variable.Base;
using __SARV.Variable.Value;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Entity
{
    [Serializable]
    public class SVVariable : SVSerializable
    {
        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Identifier")] [SerializeField] [HideLabel] [ShowIf(nameof(canSave))]
        private SARVIdentifier identifier;

        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [HideLabel]
        private string title;

        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [LabelText("CanSave?")]
        private bool canSave;

        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Value", showLabel: false)] [HorizontalGroup("$GroupTitle/Value/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetVariableValueTitles))] [OnValueChanged(nameof(OnVariableValueChanged))]
        private string valueType = "";

        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Value", showLabel: false)] [HorizontalGroup("$GroupTitle/Value/Group01")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVVariableValue variableValue = new SVVariableValueNull();

        public SARVIdentifier Identifier => identifier;
        public bool CanSave => canSave;
        public string Title => title;
        public string GroupTitle => $"{(string.IsNullOrEmpty(Title) ? "..." : Title)} ({(string.IsNullOrEmpty(valueType) ? "..." : valueType)}) = {variableValue}";

        public void SetTitle(string variableTitle)
        {
            title = variableTitle;
        }

        private void OnVariableValueChanged()
        {
            if (string.IsNullOrEmpty(valueType))
            {
                variableValue = new SVVariableValueNull();
                return;
            }

            var selectedVariableValue = SVReflection.GetVariableValueByTitle(valueType);
            if (selectedVariableValue == null || selectedVariableValue == variableValue.GetType())
            {
                return;
            }

            variableValue = Activator.CreateInstance(selectedVariableValue) as SVVariableValue;
        }

        private IEnumerable GetVariableValueTitles()
        {
            var variableValueTitles = SVReflection.GetVariableValueTitles();
            return variableValueTitles;
        }
    }
}