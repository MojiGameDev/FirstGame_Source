using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Common.Access;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Kernal.Argument;
using __SARV.Framework.Module.Dialogue.Entity;
using __SARV.Framework.Module.Dialogue.Enum;
using __SARV.Framework.Module.Subtitle;

namespace __SARV.Framework.Module.Dialogue.SubDialogue
{
    public abstract class SVSubDialogueRunner : SVSubDialogueNode
    {
        public async Task RunDialogue(SVArgument argument)
        {
            await RunDialogueChildrenNode(Dialogues);
        }

        private async Task RunDialogueNode(SVDialogueNode node)
        {
            await RunDialogueOnEnter(node);

            RunDialogueNodeType(node);
            await RunDialogueNodeAdvanceMode(node);

            await RunDialogueOnExit(node);

            await RunDialogueChildrenNode(node.Dialogues);
        }

        private async Task RunDialogueOnEnter(SVDialogueNode node)
        {
            await node.OnEnterInstruction.ExecuteInstructions(SVArgument.Create(gameObject));
        }

        private async Task RunDialogueOnExit(SVDialogueNode node)
        {
            await node.OnExitInstruction.ExecuteInstructions(SVArgument.Create(gameObject));
        }

        private async Task RunDialogueNodeAdvanceMode(SVDialogueNode node)
        {
            switch (node.AdvanceMode)
            {
                case SVDialogueNodeAdvanceMode.InputKey:
                    await RunDialogueNodeAdvanceModeInputKey(node);
                    break;
                case SVDialogueNodeAdvanceMode.Delay:
                    await RunDialogueNodeAdvanceModeDelay(node);
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
            SARVSubtitle.Instance.ShowSubtitle(node.SubtitleText, node.SubtitleDelay);
        }

        private void RunDialogueNodeTypeChoice(SVDialogueNode node)
        {
        }

        private void RunDialogueNodeTypeRandom(SVDialogueNode node)
        {
        }

        private async Task RunDialogueNodeAdvanceModeInputKey(SVDialogueNode node)
        {
            await SVAccessPlayer.Instance.WaitForInteract();
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