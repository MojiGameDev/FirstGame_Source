using System;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Enum;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Branch
{
    [SVTitle("CompareBool")]
    [SVCategory(SVConstantCategory.Branch.LOGIC)]
    [SVDescription("Compares two boolean values using an equality operator")]
    [Serializable]
    public class SVLogicBranchCompareBool : SVBranchComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<bool> leftOperand = new SVBoolProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [LabelText("Operator")]
        private SVEqualityOperatorType operatorType = SVEqualityOperatorType.Equal;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<bool> rightOperand = new SVBoolProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")} {leftOperand} {(Not ? "Is not" : "Is")} {operatorType} to {rightOperand}";

        public override bool IsTrue(SVArgument argument)
        {
            var result = false;
            switch (operatorType)
            {
                case SVEqualityOperatorType.Equal:
                    result = leftOperand.GetValue(argument) == rightOperand.GetValue(argument);
                    break;
                case SVEqualityOperatorType.NotEqual:
                    result = leftOperand.GetValue(argument) != rightOperand.GetValue(argument);
                    break;
            }

            return result;
        }
    }
}