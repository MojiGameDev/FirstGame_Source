using System;
using System.Collections.Generic;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Extension;
using __SARV.Dialogue.Enum;
using __SARV.Framework.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Dialogue.Entity
{
    [Serializable]
    public class SVDialogueNode : SVSerializable
    {
        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideLabel] [Title("Type")]
        private SVDialogueNodeType type = SVDialogueNodeType.Text;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideLabel] [Title("State")] [HideIf(nameof(IsTypeRandom))]
        private SVDialogueNodeState state = SVDialogueNodeState.Continue;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideLabel] [Title("AdvanceMode")] [HideIf(nameof(IsTypeRandom))]
        private SVDialogueNodeAdvanceMode advanceMode = SVDialogueNodeAdvanceMode.InputKey;

        [FoldoutGroup("$GroupTitle")] [SerializeReference] [HideReferenceObjectPicker] [HideLabel] [Title("Delay")] [ShowIf(nameof(IsDelayMustShowed))]
        private SVPropertyComponent<float> delay = new SVFloatProperty();

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideLabel] [Title("Text")] [HideIf(nameof(IsTypeRandom))]
        private string text;

        [FoldoutGroup("$GroupTitle")] [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [Title("")] [PropertySpace(spaceBefore: -15)] [HideIf(nameof(IsStateComplete))]
        private List<SVDialogueNode> dialogues = new();

        public string Text => text;
        public SVDialogueNodeState State => state;
        public SVDialogueNodeType Type => type;
        public SVDialogueNodeAdvanceMode AdvanceMode => advanceMode;
        public IReadOnlyList<SVDialogueNode> Dialogues => dialogues;
        public float Delay => delay.Value;

        private string GroupTitle => $"{Type.ToReadableString()} - {State.ToReadableString()} - {AdvanceMode.ToReadableString()} - {(string.IsNullOrEmpty(Text) ? "..." : Text)}";
        private bool IsStateComplete => State == SVDialogueNodeState.Complete;
        private bool IsDelayMustShowed => AdvanceMode == SVDialogueNodeAdvanceMode.Delay && !IsTypeRandom;
        private bool IsTypeRandom => Type == SVDialogueNodeType.Random;

        private void CreateNode()
        {
            dialogues.Add(new SVDialogueNode());
        }
    }
}