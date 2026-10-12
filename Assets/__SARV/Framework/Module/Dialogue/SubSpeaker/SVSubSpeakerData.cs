using __SARV.Common.Base;
using __SARV.Common.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Dialogue.SubSpeaker
{
    public abstract class SVSubSpeakerData : SVScriptableObject
    {
        [FoldoutGroup("Data")] [Title("Speaker")] [SerializeField] [HideLabel]
        protected string speaker;

        [FoldoutGroup("Data")] [Title("TextColor")] [SerializeField] [HideLabel] [ColorPalette]
        protected Color textColor;

        public string Speaker => speaker;
        public string TextColor => textColor.ToHexString();
    }
}