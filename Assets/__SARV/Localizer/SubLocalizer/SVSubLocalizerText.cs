using __SARV.Core.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Localizer.SubLocalizer
{
    public abstract class SVSubLocalizerText : SVScriptableObject
    {
        [FoldoutGroup("Text")] [Title("PersianText")] [SerializeField] [HideLabel]
        private string persianText;

        [FoldoutGroup("Text")] [Title("EnglishText")] [SerializeField] [HideLabel]
        private string englishText;

        public string PersianText => persianText;
        public string EnglishText => englishText;
    }
}