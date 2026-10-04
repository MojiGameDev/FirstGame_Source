using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
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
        private SVPropertyComponent<bool> leftSideBoolProperty = new SVBoolProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Operator")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<SVEqualityOperatorType> operatorProperty = new SVExternalPropertyEqualityOperatorType();

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("RightSide")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> rightSideBoolProperty = new SVBoolProperty();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")} {leftSideBoolProperty} {(Not ? "Is not" : "Is")} {operatorProperty} to {rightSideBoolProperty}";

        public override bool IsTrue()
        {
            var result = false;
            switch (operatorProperty.Value)
            {
                case SVEqualityOperatorType.Equal:
                    result = leftSideBoolProperty.Value == rightSideBoolProperty.Value;
                    break;
                case SVEqualityOperatorType.NotEqual:
                    result = leftSideBoolProperty.Value != rightSideBoolProperty.Value;
                    break;
            }

            return result;
        }
    }
}