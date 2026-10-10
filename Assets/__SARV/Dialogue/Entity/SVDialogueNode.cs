using System;
using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Core.Extension;
using __SARV.Dialogue.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Dialogue.Entity
{
    [Serializable]
    public class SVDialogueNode : SVSerializable
    {
        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideLabel] [Title("Type")]
        private SVDialogueNodeType type = SVDialogueNodeType.Text;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideLabel] [Title("State")]
        private SVDialogueNodeState state = SVDialogueNodeState.Continue;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideLabel] [Title("Text")]
        private string text;

        [FoldoutGroup("$GroupTitle")] [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [HideIf(nameof(IsNodeStateComplete))]
        private List<SVDialogueNode> nodes = new();

        public string Text => text;
        public SVDialogueNodeState State => state;
        public SVDialogueNodeType Type => type;

        private string GroupTitle => $"{type.ToReadableString()} - {state.ToReadableString()} - {(string.IsNullOrEmpty(Text) ? "..." : Text)}";
        private bool IsNodeStateComplete => state == SVDialogueNodeState.Complete;

        private void CreateNode()
        {
            nodes.Add(new SVDialogueNode());
        }
    }
}