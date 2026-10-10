using System;
using System.Collections.Generic;
using __SARV.Dialogue.Data;
using __SARV.Dialogue.Entity;
using UnityEngine;

namespace __SARV.Dialogue.Node
{
    [Serializable]
    public class SVDialogueChoiceNode : SVDialogueNode
    {
        [SerializeField] private string prompt;

        [SerializeField] private List<SVDialogueChoice> choices = new();

        public string Prompt => prompt;
        public IReadOnlyList<SVDialogueChoice> Choices => choices;

        public override void Execute(SARVDialogue dialogue)
        {
            //runner.ShowChoices(this);
        }
    }
}