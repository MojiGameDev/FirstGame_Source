using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Dialogue.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Dialogue.SubDialogue
{
    public abstract class SVSubDialogueNode : SVMonoBehaviour
    {
        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))]
        private List<SVDialogueNode> nodes = new();

        private void CreateNode()
        {
            nodes.Add(new SVDialogueNode());
        }
    }
}