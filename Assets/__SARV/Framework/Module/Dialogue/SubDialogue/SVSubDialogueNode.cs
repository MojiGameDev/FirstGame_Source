using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Common.Base;
using __SARV.Framework.Module.Dialogue.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Dialogue.SubDialogue
{
    public abstract class SVSubDialogueNode : SVKernal
    {
        [SerializeField] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [LabelText("$" + nameof(DialoguesLabel))]
        protected List<SVDialogueNode> dialogues = new();

        private string DialoguesLabel => $"{dialogues.Count} Dialogues";

        private void CreateNode()
        {
            dialogues.Add(new SVDialogueNode());
        }
    }
}