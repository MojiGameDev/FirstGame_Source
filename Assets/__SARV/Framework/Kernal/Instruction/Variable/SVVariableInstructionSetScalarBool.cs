using System;
using System.Collections;
using System.Threading.Tasks;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Variable;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction.Variable
{
    [SVTitle("SetScalarBool")]
    [SVCategory(SVConstantCategory.Instruction.VARIABLE)]
    [SVDescription("Sets the value of an Scalar Bool Variable")]
    [Serializable]
    public class SVVariableInstructionSetScalarBool : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVScalarVariable variable;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [ValueDropdown(nameof(GetAllVariableNames))] [Required]
        private string variableName = "";

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [HideLabel] [SVRequired]
        private SVPropertyComponent<bool> variableValue = new SVBoolProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Set {variableValue} to {variableName}";

        protected override Task ExecuteInternal(SVArgument argument)
        {
            var value = variableValue.GetValue(argument);
            variable.SetValue(variableName, value);
            return SVTaskUtils.OK_RESULT;
        }

        private IEnumerable GetAllVariableNames()
        {
            if (variable == null)
            {
                return null;
            }

            var variableNames = variable.GetAllNamesByValueType<SVVariableBool>();
            return variableNames;
        }
    }
}