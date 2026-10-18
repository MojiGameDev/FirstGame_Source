using UnityEngine;

namespace __SARV.Framework.Module.Localizer.SubLocalizer
{
    public abstract class SVSubLocalizerManager : SVSubLocalizerVoice
    {
        public string TranslateText()
        {
            return englishText;
        }

        public AudioClip TranslateVoice()
        {
            return englishVoice;
        }
    }
}