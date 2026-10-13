using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Localizer.SubLocalizer
{
    public abstract class SVSubLocalizerText : SVScriptableObject
    {
        [FoldoutGroup("Text")] [SerializeField]
        protected string persianText;

        [FoldoutGroup("Text")] [SerializeField]
        protected string englishText;

        public string PersianText => persianText;
        public string EnglishText => englishText;
    }
}