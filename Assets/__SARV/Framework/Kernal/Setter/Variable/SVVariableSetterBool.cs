using System;
using System.Collections;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Variable;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Setter
{
    [SVTitle("Bool")]
    [SVCategory(SVConstantCategory.Setter.VARIABLE)]
    [SVDescription("Set a Bool Variable")]
    [Serializable]
    public class SVVariableSetterBool : SVSetterComponent<bool>
    {
        [SerializeField] [Required] private SARVVariable variable;

        [SerializeField] [ValueDropdown(nameof(GetAllVariableNames))] [Required]
        private string variableName = "";

        public override string ToString()
        {
            return $"Variable ({(string.IsNullOrEmpty(variableName) ? "..." : variableName)})";
        }

        public override void SetValue(SVArgument argument, bool value)
        {
            variable.SetValue(variableName, value);
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