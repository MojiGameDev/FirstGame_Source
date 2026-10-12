using __SARV.Common.Base;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Service.Localizer.SubLocalizer
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