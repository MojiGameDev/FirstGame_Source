using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVAction : SVMonoBehaviour
    {
        [BoxGroup("Row01", showLabel: false)] [HorizontalGroup("Row01/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllInstructionComponents))] [OnValueChanged(nameof(OnInstructionChanged), InvokeOnInitialize = true)]
        private string instruction = "";

        [BoxGroup("Row01", showLabel: false)]
        [HorizontalGroup("Row01/Group01", Width = 21)]
        [HideLabel]
        [Button(ButtonSizes.Medium, Icon = SdfIconType.Plus, ButtonHeight = 21)]
        [EnableIf(nameof(IsInstructionValid))]
        private void AddNewInstruction()
        {
            if (IsInstructionValid)
            {
                var selectedComponentType = SVReflection.GetInstructionByPath(instruction);
                var instructionComponent = (SVInstructionComponent)Activator.CreateInstance(selectedComponentType);
                Instructions.Add(instructionComponent);
                instruction = "";
            }
        }

        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnInstructionsChanged))]
        private List<SVInstructionComponent> instructions = new();

        public List<SVInstructionComponent> Instructions => instructions;
        private bool IsInstructionValid => !string.IsNullOrEmpty(instruction);

        private void OnInstructionChanged()
        {
        }

        private void OnInstructionsChanged()
        {
        }

        private IEnumerable GetAllInstructionComponents()
        {
            var components = SVReflection.GetAllInstructionComponentPaths();
            return components.Select(d => new ValueDropdownItem(d, d));
        }
    }
}