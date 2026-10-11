using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Dialogue.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Dialogue.SubDialogue
{
    public abstract class SVSubDialogueNode : SVMonoBehaviour
    {
        [SerializeField] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))]
        private List<SVDialogueNode> dialogues = new();

        public IReadOnlyList<SVDialogueNode> Dialogues => dialogues;

        private void CreateNode()
        {
            dialogues.Add(new SVDialogueNode());
        }
    }
}