using System.Collections.Generic;
using __SARV.Common.Extension;
using DG.Tweening;
using MEC;
using UnityEngine;
using UnityEngine.UI;

namespace __SARV.Framework.Module.Subtitle.SubSubtitle
{
    public abstract class SVSubSubtitleManager : SVSubSubtitleSetting
    {
        // Index 0 is always the newest subtitle.
        private readonly List<SARVSubtitleView> _subtitles = new();
        private readonly Dictionary<SARVSubtitleView, CoroutineHandle> _removalHandles = new();

        protected override void OnDestroy()
        {
            base.OnDestroy();
            foreach (var handle in _removalHandles.Values)
            {
                Timing.KillCoroutines(handle);
            }

            _removalHandles.Clear();

            foreach (var subtitle in _subtitles)
            {
                if (subtitle == null)
                {
                    continue;
                }

                subtitle.RectTransform.DOKill();
            }

            _subtitles.Clear();
        }

        /// <summary>
        /// Displays a subtitle at the bottom of the subtitle stack.
        /// </summary>
        public void ShowSubtitle(string text, float duration = -1)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            if (duration.ApproximatelyEquals(-1))
            {
                duration = defaultDuration;
            }

            var subtitle = Instantiate(subtitlePrefab, subtitleContainer, false);

            subtitle.SetText(text);

            // Update TMP and UI layout before reading the height.
            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(subtitle.RectTransform);

            subtitle.RectTransform.anchoredPosition = Vector2.zero;

            _subtitles.Insert(0, subtitle);

            RepositionSubtitles();

            var handle = Timing.RunCoroutine(RemoveAfterDuration(subtitle, duration), Segment.Update);

            _removalHandles[subtitle] = handle;
        }

        /// <summary>
        /// Moves the newest subtitle to the bottom and
        /// stacks all remaining subtitles above it.
        /// </summary>
        private void RepositionSubtitles()
        {
            var y = 0f;

            foreach (var subtitle in _subtitles)
            {
                if (subtitle == null)
                {
                    continue;
                }

                var rectTransform = subtitle.RectTransform;

                var targetPosition = new Vector2(0f, y);

                rectTransform.DOKill();

                rectTransform.DOAnchorPos(targetPosition, moveDuration)
                    .SetEase(moveEase)
                    .SetLink(subtitle.gameObject);

                y += subtitle.Height + spacing;
            }
        }

        /// <summary>
        /// Removes a subtitle after the configured duration.
        /// </summary>
        private IEnumerator<float> RemoveAfterDuration(SARVSubtitleView subtitle, float duration)
        {
            yield return Timing.WaitForSeconds(duration);

            if (subtitle == null)
            {
                _removalHandles.Remove(subtitle);
                yield break;
            }

            _subtitles.Remove(subtitle);
            _removalHandles.Remove(subtitle);

            subtitle.RectTransform.DOKill();

            Destroy(subtitle.gameObject);

            RepositionSubtitles();
        }
    }
}