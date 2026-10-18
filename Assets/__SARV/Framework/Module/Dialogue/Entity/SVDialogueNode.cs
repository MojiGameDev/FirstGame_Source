using System;
using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Shared;
using __SARV.Framework.Module.Dialogue.Enum;
using __SARV.Framework.Module.Localizer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Dialogue.Entity
{
    [Serializable]
    public class SVDialogueNode : SVSerializable
    {
        [FoldoutGroup("$GroupTitle")] [SerializeField]
        private SVDialogueNodeType type = SVDialogueNodeType.Text;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideIf(nameof(IsTypeRandom))]
        private SVDialogueNodeAdvanceMode advanceMode = SVDialogueNodeAdvanceMode.Interact;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [ShowIf(nameof(IsDelayMustShowed))] [PropertyRange(0f, 15f)]
        private float delay = 4f;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideIf(nameof(IsTypeRandom))] [Required]
        private SARVLocalizer text;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideIf(nameof(IsTypeRandom))] [PropertyRange(0f, 15f)]
        private float subtitleDelay = 2f;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [HideIf(nameof(IsTypeRandom))] [Required]
        private SARVSpeaker speaker;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [Title("OnEnter")] [HideLabel]
        private SVInstruction onEnterInstruction;

        [FoldoutGroup("$GroupTitle")] [SerializeField] [Title("OnExit")] [HideLabel]
        private SVInstruction onExitInstruction;

        [FoldoutGroup("$GroupTitle")] [SerializeReference] [HideReferenceObjectPicker] [LabelText("$DialoguesLabel")] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [Title("")] [PropertySpace(spaceBefore: -15)]
        private List<SVDialogueNode> dialogues = new();

        private string DialoguesLabel => $"{dialogues.Count} Sub Dialogues";
        public string Text => text.TranslateText();
        public AudioClip Voice => text.TranslateVoice();
        public SVDialogueNodeType Type => type;
        public SVDialogueNodeAdvanceMode AdvanceMode => advanceMode;
        public IReadOnlyList<SVDialogueNode> Dialogues => dialogues;
        public float Delay => delay;
        public SARVSpeaker Speaker => speaker;
        public SVInstruction OnEnterInstruction => onEnterInstruction;
        public SVInstruction OnExitInstruction => onExitInstruction;

        private string GroupTitle => $"{Type.ToReadableString()} - {AdvanceMode.ToReadableString()} - {(text == null ? "..." : text.name)}";
        private bool IsDelayMustShowed => AdvanceMode == SVDialogueNodeAdvanceMode.Delay && !IsTypeRandom;
        private bool IsTypeRandom => Type == SVDialogueNodeType.Random;
        public string SubtitleText => $"<color=#{speaker.TextColor}>{speaker.SpeakerName}:</color> {Text}";
        public float SubtitleDelay => subtitleDelay;

        private void CreateNode()
        {
            dialogues.Add(new SVDialogueNode());
        }
    }
}