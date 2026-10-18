using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Localizer.SubLocalizer
{
    public abstract class SVSubLocalizerVoice : SVSubLocalizerText
    {
        [FoldoutGroup("Text")] [SerializeField]
        protected bool hasVoice;

        [FoldoutGroup("Text")] [SerializeField] [ShowIf(nameof(hasVoice))]
        protected AudioClip persianVoice;

        [FoldoutGroup("Text")] [SerializeField] [ShowIf(nameof(hasVoice))]
        protected AudioClip englishVoice;
    }
}