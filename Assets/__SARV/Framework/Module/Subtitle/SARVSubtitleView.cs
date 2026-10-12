using __SARV.Common.Base;
using TMPro;
using UnityEngine;

namespace __SARV.Framework.Module.Subtitle
{
    public class SARVSubtitleView : SVMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI subtitleText;

        public RectTransform RectTransform { get; private set; }

        public float Height => RectTransform.rect.height;

        private void Awake()
        {
            RectTransform = (RectTransform)transform;
        }

        public void SetText(string text)
        {
            subtitleText.text = text;
        }
    }
}