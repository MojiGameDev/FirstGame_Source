using System;
using System.Collections;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Module.Variable;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Variable")]
    [SVCategory(SVConstantCategory.Property.BOOL)]
    [SVDescription("Bool Variable")]
    [Serializable]
    public class SVBoolPropertyVariable : SVPropertyComponent<bool>
    {
        [SerializeField] [Required] private SARVVariable variable;

        [SerializeField] [ValueDropdown(nameof(GetAllVariableNames))] [Required]
        private string variableName = "";

        public override string ToString()
        {
            return $"Variable ({(string.IsNullOrEmpty(variableName) ? "..." : variableName)})";
        }

        public override bool GetValue(SVArgument argument)
        {
            return variable.GetValue<bool>(variableName);
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