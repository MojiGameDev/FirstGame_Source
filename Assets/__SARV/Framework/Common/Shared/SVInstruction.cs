using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Shared
{
    [Serializable]
    public class SVInstruction : SVSerializable
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
                instructions.Add(instructionComponent);
                instruction = "";
            }
        }

        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnInstructionsChanged))] [PropertyOrder(int.MaxValue)]
        protected List<SVInstructionComponent> instructions = new();

        private bool IsInstructionValid => !string.IsNullOrEmpty(instruction);
        
        public async Task ExecuteInstructions(SVArgument argument)
        {
            foreach (var instructionComponent in instructions)
            {
                await instructionComponent.Execute(argument);
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