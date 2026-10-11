using System.Collections.Generic;
using System.Threading.Tasks;
using __SARV.Dialogue.Entity;
using __SARV.Framework.Argument;
using UnityEngine;

namespace __SARV.Dialogue.SubDialogue
{
    public abstract class SVSubDialogueRunner : SVSubDialogueNode
    {
        public async Task RunDialogue(SVArgument argument)
        {
            RunDialogueChildrenNode(Dialogues);
            await Task.CompletedTask;
        }
        
        private void RunDialogueNode(SVDialogueNode node)
        {
            Debug.Log(node.Text);

            RunDialogueChildrenNode(node.Dialogues);
        }
        
        private void RunDialogueChildrenNode(IReadOnlyList<SVDialogueNode> dialogues)
        {
            foreach (var child in dialogues)
            {
                RunDialogueNode(child);
            }
        }
    }
}