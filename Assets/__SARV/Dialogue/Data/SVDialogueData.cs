using System.Collections.Generic;
using __SARV.Core.Base;
using UnityEngine;

namespace __SARV.Dialogue.Data
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "SARV/Dialogue/New")]
    public class SVDialogueData : SVScriptableObject
    {
        [SerializeField] private List<SVDialogueNode> nodes = new();

        [SerializeField] private string startNodeID;

        public string StartNodeID => startNodeID;
        public IReadOnlyList<SVDialogueNode> Nodes => nodes;

        public SVDialogueNode GetNode(string id)
        {
            return nodes.Find(node => node.ID == id);
        }
    }
}