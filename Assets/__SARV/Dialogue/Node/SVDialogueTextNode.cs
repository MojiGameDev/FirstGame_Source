using System;
using __SARV.Dialogue.Data;
using UnityEngine;

namespace __SARV.Dialogue.Node
{
    [Serializable]
    public class SVDialogueTextNode : SVDialogueNode
    {
        [SerializeField] private string speaker;

        [TextArea(2, 5)]
        [SerializeField] private string text;

        [SerializeField] private string nextNodeID;

        public string Speaker => speaker;
        public string Text => text;
        public string NextNodeID => nextNodeID;

        public override void Execute(SARVDialogue dialogue)
        {
            //runner.ShowText(this);
        }
    }
}