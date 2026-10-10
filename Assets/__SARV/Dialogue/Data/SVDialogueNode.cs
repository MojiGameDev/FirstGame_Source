using System;
using __SARV.Core.Base;
using UnityEngine;

namespace __SARV.Dialogue.Data
{
    [Serializable]
    public abstract class SVDialogueNode : SVSerializable
    {
        [SerializeField] private string id;

        public string ID => id;

        public abstract void Execute(SARVDialogue dialogue);
    }
}