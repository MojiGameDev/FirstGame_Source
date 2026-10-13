using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Localizer.SubLocalizer
{
    public abstract class SVSubLocalizerVoice : SVSubLocalizerText
    {
        [FoldoutGroup("Text")] [SerializeField]
        protected bool hasVoice;

        [FoldoutGroup("Text")] [SerializeField] [ShowIf(nameof(HasVoice))]
        protected SARVIdentifier persianVoiceIdentifier;

        [FoldoutGroup("Text")] [SerializeField] [ShowIf(nameof(HasVoice))]
        protected SARVIdentifier englishVoiceIdentifier;

        public bool HasVoice => hasVoice;
        public SARVIdentifier PersianVoiceIdentifier => persianVoiceIdentifier;
        public SARVIdentifier EnglishVoiceIdentifier => englishVoiceIdentifier;
    }
}