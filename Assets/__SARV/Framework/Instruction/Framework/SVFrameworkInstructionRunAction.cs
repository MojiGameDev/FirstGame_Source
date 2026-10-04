using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Instruction.Framework
{
    [SVTitle("RunAction")]
    [SVCategory(SVConstantCategory.Instruction.FRAMEWORK)]
    [SVDescription("Executes the specified action")]
    [Serializable]
    public class SVFrameworkInstructionRunAction : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Action")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<SARVAction> actionProperty = new SVExternalPropertySARVAction();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(actionProperty == null ? "..." : actionProperty)}";
    }
}