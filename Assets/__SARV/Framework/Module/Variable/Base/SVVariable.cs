using System;
using System.Collections;
using __SARV.Common.Base;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Module.Variable.Value;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable.Base
{
    [Serializable]
    public abstract class SVVariable<TSaveType> : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Key", showLabel: false)] [SerializeField] [HideLabel] [ShowIf(nameof(canSave))]
        private TSaveType key;

        [FoldoutGroup("$GroupTitle")]
        [BoxGroup("$GroupTitle/Key")]
        [ShowIf(nameof(canSave))]
        [Button]
        [ShowIf(nameof(MustShowGenerateKey))]
        private void GenerateKey()
        {
            key = (TSaveType)Convert.ChangeType(
                SVGeneralUtils.NewSaveKey(),
                typeof(TSaveType)
            );
        }

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [HideLabel]
        private string title;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [LabelText("CanSave?")]
        private bool canSave;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Value", showLabel: false)] [HorizontalGroup("$GroupTitle/Value/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetVariableValueTitles))] [OnValueChanged(nameof(OnVariableValueChanged))]
        private string valueType = "";

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Value", showLabel: false)] [HorizontalGroup("$GroupTitle/Value/Group01")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVVariableValue variableValue = new SVVariableValueNull();

        public TSaveType Key => key;
        public bool CanSave => canSave;
        private bool MustShowGenerateKey => canSave && typeof(TSaveType) == typeof(string);
        public string Title => title;
        public string GroupTitle => $"{(canSave ? "Saved - " : "")}{(string.IsNullOrEmpty(Title) ? "..." : Title)} ({(string.IsNullOrEmpty(valueType) ? "..." : valueType)} = {variableValue})";

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