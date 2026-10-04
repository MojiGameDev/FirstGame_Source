using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Instruction
{
    [SVTitle("RunAction")]
    [SVCategory(SVConstantCategory.Instruction.FRAMEWORK)]
    [SVDescription("Executes the specified action")]
    [Serializable]
    public class SVFrameworkInstructionRunAction : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Action")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<SARVAction> actionProperty = new SVExternalPropertySARVAction();

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinishProperty = new SVBoolPropertyManual();

        private bool IsActionPropertyNull => actionProperty == null || actionProperty.Value == null;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(IsActionPropertyNull ? "..." : actionProperty)}";
    }
}