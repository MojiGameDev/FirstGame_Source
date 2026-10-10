using __SARV.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Localizer.SubLocalizer
{
    public abstract class SVSubLocalizerVoice : SVSubLocalizerText
    {
        [FoldoutGroup("Text")] [Title("HasVoice?")] [SerializeField] [HideLabel]
        private bool hasVoice;

        [FoldoutGroup("Text")] [Title("PersianVoice")] [SerializeField] [HideLabel]
        private SARVIdentifier persianVoiceIdentifier;

        [FoldoutGroup("Text")] [Title("EnglishVoice")] [SerializeField] [HideLabel]
        private SARVIdentifier englishVoiceIdentifier;

        public bool HasVoice => hasVoice;
        public SARVIdentifier PersianVoiceIdentifier => persianVoiceIdentifier;
        public SARVIdentifier EnglishVoiceIdentifier => englishVoiceIdentifier;
    }
}