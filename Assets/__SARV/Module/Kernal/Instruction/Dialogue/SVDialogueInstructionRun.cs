using System;
using System.Threading.Tasks;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using __SARV.Dialogue;
using __SARV.Framework.Argument;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Instruction.Dialogue
{
    [SVTitle("Run")]
    [SVCategory(SVConstantCategory.Instruction.DIALOGUE)]
    [SVDescription("Executes the specified dialogue")]
    [Serializable]
    public class SVDialogueInstructionRun : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("Dialogue")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SARVDialogue dialogue;

        [FoldoutGroup("$" + nameof(GroupTitle))] [Title("WaitToFinish")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<bool> waitToFinish = new SVBoolPropertyManual();

        private bool IsDialogueNull => dialogue == null;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Executes the {(IsDialogueNull ? "..." : dialogue)}";

        protected override async Task ExecuteInternal(SVArgument argument)
        {
            if (waitToFinish.Value)
            {
                await dialogue.RunDialogue(argument);
                return;
            }
            _ = dialogue.RunDialogue(argument);
        }
    }
}