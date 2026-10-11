using System;
using System.Threading.Tasks;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Framework.Argument;
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
        private SARVAction action;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinish = new SVBoolPropertyManual();

        private bool IsActionNull => action == null || action == null;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(IsActionNull ? "..." : action)}";

        protected override async Task ExecuteInternal(SVArgument argument)
        {
            if (waitToFinish.Value)
            {
                await action.RunAction(argument);
                return;
            }
            _ = action.RunAction(argument);
        }
    }
}