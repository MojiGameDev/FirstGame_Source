using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Subtitle.SubSubtitle
{
    public abstract class SVSubSubtitleReference : SVSingletonGlobalMonoBehaviour<SARVSubtitle>
    {
        [FoldoutGroup("Reference")] [SerializeField] [Title("Container")] [Required] [HideLabel]
        protected RectTransform subtitleContainer;

        [FoldoutGroup("Reference")] [SerializeField] [Title("PrefabView")] [AssetsOnly] [Required] [HideLabel]
        protected SARVSubtitleView subtitlePrefab;
    }
}