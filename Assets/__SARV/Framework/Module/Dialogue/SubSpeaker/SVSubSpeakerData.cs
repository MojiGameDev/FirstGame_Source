using __SARV.Common.Base;
using __SARV.Common.Extension;
using __SARV.Framework.Module.Localizer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Dialogue.SubSpeaker
{
    public abstract class SVSubSpeakerData : SVScriptableObject
    {
        [FoldoutGroup("Data")] [SerializeField]
        protected SARVLocalizer speakerName;

        [FoldoutGroup("Data")] [SerializeField] [ColorPalette]
        protected Color textColor;
        
        public string SpeakerName => speakerName.TranslateText();
        public string TextColor => textColor.ToHexString();
    }
}