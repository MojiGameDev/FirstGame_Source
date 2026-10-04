using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Component;
using __SARV.Core.Reflection;
using __SARV.Framework.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Core.Base
{
    public class SVInstructionMonoBehaviour : SVMonoBehaviour
    {
        [BoxGroup("ActionRow01", showLabel: false)] [HorizontalGroup("ActionRow01/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllInstructionComponents))] [OnValueChanged(nameof(OnInstructionChanged), InvokeOnInitialize = true)] [PropertyOrder(int.MaxValue)]
        protected string instruction = "";

        [BoxGroup("ActionRow01", showLabel: false)]
        [HorizontalGroup("ActionRow01/Group01", Width = 21)]
        [HideLabel]
        [Button(ButtonSizes.Medium, Icon = SdfIconType.Plus, ButtonHeight = 21)]
        [EnableIf(nameof(IsInstructionValid))]
        [PropertyOrder(int.MaxValue)]
        protected void AddNewInstruction()
        {
            if (IsInstructionValid)
            {
                var selectedComponentType = SVReflection.GetInstructionByPath(instruction);
                var instructionComponent = (SVInstructionComponent)Activator.CreateInstance(selectedComponentType);
                Instructions.Add(instructionComponent);
                instruction = "";
            }
        }

        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnInstructionsChanged))] [PropertyOrder(int.MaxValue)]
        protected List<SVInstructionComponent> instructions = new();

        public List<SVInstructionComponent> Instructions => instructions;
        private bool IsInstructionValid => !string.IsNullOrEmpty(instruction);
        
        protected void ExecuteInstructions(SVArgument argument)
        {
            foreach (var instructionComponent in instructions)
            {
                instructionComponent.Execute(argument);
            }
        }

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