using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Core.Enum;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Branch.Logic
{
    [SVTitle("CompareBool")]
    [SVCategory(SVConstantCategory.Branch.COMPARE_BOOL)]
    [SVDescription("Compares two boolean values using an equality operator")]
    [Serializable]
    public class SVLogicBranchCompareBool : SVBranchComponent
    {
        [Title("LeftSide")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> leftSideBoolProperty = new SVBoolProperty();

        [Title("Operator")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<SVEqualityOperatorType> operatorProperty = new SVExternalPropertyEqualityOperatorType();

        [Title("RightSide")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> rightSideBoolProperty = new SVBoolProperty();

        // public override string GetTitle(bool checkNot)
        // {
        //     return $"{leftSideBoolProperty} {(checkNot ? "Is not" : "Is")} {operatorProperty} {rightSideBoolProperty}";
        // }

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