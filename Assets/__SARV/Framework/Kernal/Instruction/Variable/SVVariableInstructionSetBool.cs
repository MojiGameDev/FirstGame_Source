using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction.Variable
{
    [SVTitle("SetBool")]
    [SVCategory(SVConstantCategory.Instruction.VARIABLE)]
    [SVDescription("Sets the value of a Bool Variable")]
    [Serializable]
    public class SVVariableInstructionSetBool : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [HideLabel] [SVRequired]
        private SVPropertyComponent<bool> variable = new SVBoolPropertyVariable();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [HideLabel] [SVRequired]
        private SVPropertyComponent<bool> variableValue = new SVBoolProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Set {variableValue} to {variable}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var value = variableValue.GetValue(argument);
            variable.SetValue(argument, value);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}