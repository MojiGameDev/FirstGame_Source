using System;
using __SARV.Core.Base;

namespace __SARV.Dialogue.Entity
{
    [Serializable]
    public class SVDialogueChoice : SVSerializable
    {
        public string text;
        public string nextNodeID;
    }
}