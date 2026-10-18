using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Dialogue;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("Run")]
    [SVCategory(SVConstantCategory.Instruction.DIALOGUE)]
    [SVDescription("Executes the specified dialogue")]
    [Serializable]
    public class SVDialogueInstructionRun : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [SVRequired]
        private SARVDialogue dialogue;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private bool waitToFinish = false;

        private bool IsDialogueNull => dialogue == null;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Executes the {(IsDialogueNull ? "..." : dialogue)}";

        protected override async Task ExecuteInternal(SVArgument argument)
        {
            if (waitToFinish)
            {
                await dialogue.RunDialogue(argument);
                return;
            }

            _ = dialogue.RunDialogue(argument);
        }
    }
}