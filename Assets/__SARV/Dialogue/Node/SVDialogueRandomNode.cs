using System;
using System.Collections.Generic;
using __SARV.Dialogue.Data;
using UnityEngine;

namespace __SARV.Dialogue.Node
{
    [Serializable]
    public class SVDialogueRandomNode : SVDialogueNode
    {
        [SerializeField]
        private List<string> nextNodeIDs = new();

        public override void Execute(SARVDialogue dialogue)
        {
            // if (nextNodeIDs.Count == 0)
            // {
            //     runner.Stop();
            //     return;
            // }
            //
            // int index = UnityEngine.Random.Range(0, nextNodeIDs.Count);
            //
            // runner.GoTo(nextNodeIDs[index]);
        }
    }
}