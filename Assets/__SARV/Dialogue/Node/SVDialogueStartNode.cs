using System;
using __SARV.Dialogue.Data;
using UnityEngine;

namespace __SARV.Dialogue.Node
{
    [Serializable]
    public class SVDialogueStartNode : SVDialogueNode
    {
        [SerializeField] private string nextNodeID;

        public override void Execute(SARVDialogue dialogue)
        {
            //runner.GoTo(nextNodeID);
        }
    }
}