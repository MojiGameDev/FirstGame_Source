using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Core.Utils;
using __SARV.Dialogue.Entity;
using __SARV.Dialogue.Enum;
using __SARV.Framework.Argument;
using UnityEngine;

namespace __SARV.Dialogue.SubDialogue
{
    public abstract class SVSubDialogueRunner : SVSubDialogueNode
    {
        public async Task RunDialogue(SVArgument argument)
        {
            await RunDialogueChildrenNode(Dialogues);
        }

        private async Task RunDialogueNode(SVDialogueNode node)
        {
            RunDialogueNodeType(node);
            RunDialogueNodeState(node);
            await RunDialogueNodeAdvanceMode(node);

            await RunDialogueChildrenNode(node.Dialogues);
        }

        private async Task RunDialogueNodeAdvanceMode(SVDialogueNode node)
        {
            switch (node.AdvanceMode)
            {
                case SVDialogueNodeAdvanceMode.InputKey:
                    RunDialogueNodeAdvanceModeInputKey(node);
                    break;
                case SVDialogueNodeAdvanceMode.Delay:
                    await RunDialogueNodeAdvanceModeDelay(node);
                    break;
            }
        }

        private void RunDialogueNodeState(SVDialogueNode node)
        {
            switch (node.State)
            {
                case SVDialogueNodeState.Continue:
                    RunDialogueNodeStateContinue(node);
                    break;
                case SVDialogueNodeState.Complete:
                    RunDialogueNodeStateComplete(node);
                    break;
            }
        }

        private void RunDialogueNodeType(SVDialogueNode node)
        {
            switch (node.Type)
            {
                case SVDialogueNodeType.Text:
                    RunDialogueNodeTypeText(node);
                    break;
                case SVDialogueNodeType.Choice:
                    RunDialogueNodeTypeChoice(node);
                    break;
                case SVDialogueNodeType.Random:
                    RunDialogueNodeTypeRandom(node);
                    break;
            }
        }

        private void RunDialogueNodeTypeText(SVDialogueNode node)
        {
            Debug.Log(node.Text);
        }

        private void RunDialogueNodeTypeChoice(SVDialogueNode node)
        {
        }

        private void RunDialogueNodeTypeRandom(SVDialogueNode node)
        {
        }

        private void RunDialogueNodeStateContinue(SVDialogueNode node)
        {
        }

        private void RunDialogueNodeStateComplete(SVDialogueNode node)
        {
        }

        private void RunDialogueNodeAdvanceModeInputKey(SVDialogueNode node)
        {
        }

        private async Task RunDialogueNodeAdvanceModeDelay(SVDialogueNode node)
        {
            await SVTaskUtils.Wait(node.Delay, true);
        }

        private async Task RunDialogueChildrenNode(IReadOnlyList<SVDialogueNode> dialogues)
        {
            foreach (var child in dialogues)
            {
                await RunDialogueNode(child);
            }
        }
    }
}