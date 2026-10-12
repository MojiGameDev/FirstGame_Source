using __SARV.Framework.Integration.OdinInspector.Runtime;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Subtitle.SubSubtitle
{
    public abstract class SVSubSubtitleSetting : SVSubSubtitleReference
    {
        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0f, 15f)] [HideLabel]
        protected float spacing = 8f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0f, 5f)] [HideLabel]
        protected float duration = 3f;

        [FoldoutGroup("Setting")] [SerializeField] [PropertyRange(0f, 0.5f)] [HideLabel]
        protected float moveDuration = 0.25f;

        [FoldoutGroup("Setting")] [SerializeField] [HideLabel]
        protected Ease moveEase = Ease.OutCubic;

        [FoldoutGroup("Setting")] [SerializeField] [HideLabel]
        protected string fullName = "";
    }
}