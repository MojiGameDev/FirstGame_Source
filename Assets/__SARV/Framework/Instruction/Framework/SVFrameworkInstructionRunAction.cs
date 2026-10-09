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
        private SARVAction sarvAction;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinish = new SVBoolPropertyManual();

        private bool IsActionPropertyNull => sarvAction == null || sarvAction == null;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Execute the instructions for the {(IsActionPropertyNull ? "..." : sarvAction)}";

        protected override async Task ExecuteInternal(SVArgument argument)
        {
            if (waitToFinish.Value)
            {
                await sarvAction.RunAction(argument);
                return;
            }
            _ = sarvAction.RunAction(argument);
        }
    }
}