using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using __SARV.Framework.Argument;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Branch
{
    [SVTitle("CompareBool")]
    [SVCategory(SVConstantCategory.Branch.LOGIC)]
    [SVDescription("Compares two boolean values using an equality operator")]
    [Serializable]
    public class SVLogicBranchCompareBool : SVBranchComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("LeftSide")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> leftSideBool = new SVBoolProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Operator")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVEqualityOperatorType operatorType = SVEqualityOperatorType.Equal;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("RightSide")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> rightSideBool = new SVBoolProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")} {leftSideBool} {(Not ? "Is not" : "Is")} {operatorType} to {rightSideBool}";

        public override bool IsTrue(SVArgument argument)
        {
            var result = false;
            switch (operatorType)
            {
                case SVEqualityOperatorType.Equal:
                    result = leftSideBool.Value == rightSideBool.Value;
                    break;
                case SVEqualityOperatorType.NotEqual:
                    result = leftSideBool.Value != rightSideBool.Value;
                    break;
            }

            return result;
        }
    }
}