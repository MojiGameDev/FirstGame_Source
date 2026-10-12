using System.Collections.Generic;
using DG.Tweening;
using MEC;
using UnityEngine;
using UnityEngine.UI;

namespace __SARV.Framework.Module.Subtitle.SVSubSubtitle
{
    public abstract class SVSubSubtitleManager : SVSubSubtitleSetting
    {
        // Index 0 is always the newest subtitle.
        private readonly List<SARVSubtitleView> subtitles = new();

        private readonly Dictionary<SARVSubtitleView, CoroutineHandle> removalHandles = new();

        protected override void OnDestroy()
        {
            base.OnDestroy();
            foreach (var handle in removalHandles.Values)
            {
                Timing.KillCoroutines(handle);
            }

            removalHandles.Clear();

            foreach (var subtitle in subtitles)
            {
                if (subtitle == null)
                {
                    continue;
                }

                subtitle.RectTransform.DOKill();
            }

            subtitles.Clear();
        }

        /// <summary>
        /// Displays a subtitle at the bottom of the subtitle stack.
        /// </summary>
        public void ShowSubtitle(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            if (subtitleContainer == null || subtitlePrefab == null)
            {
                Debug.LogError("SVSubtitleSystem: Container or prefab is not assigned.", this);
                return;
            }

            SARVSubtitleView subtitle = Instantiate(subtitlePrefab, subtitleContainer, false);

            subtitle.SetText(text);

            // Update TMP and UI layout before reading the height.
            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(subtitle.RectTransform);

            subtitle.RectTransform.anchoredPosition = Vector2.zero;

            subtitles.Insert(0, subtitle);

            RepositionSubtitles();

            CoroutineHandle handle = Timing.RunCoroutine(RemoveAfterDuration(subtitle), Segment.Update);

            removalHandles[subtitle] = handle;
        }

        /// <summary>
        /// Moves the newest subtitle to the bottom and
        /// stacks all remaining subtitles above it.
        /// </summary>
        private void RepositionSubtitles()
        {
            float y = 0f;

            for (int i = 0; i < subtitles.Count; i++)
            {
                SARVSubtitleView subtitle = subtitles[i];

                if (subtitle == null)
                    continue;

                RectTransform rect = subtitle.RectTransform;

                Vector2 targetPosition = new Vector2(0f, y);

                rect.DOKill();

                rect.DOAnchorPos(targetPosition, moveDuration)
                    .SetEase(moveEase)
                    .SetLink(subtitle.gameObject);

                y += subtitle.Height + spacing;
            }
        }

        /// <summary>
        /// Removes a subtitle after the configured duration.
        /// </summary>
        private IEnumerator<float> RemoveAfterDuration(SARVSubtitleView subtitle)
        {
            yield return Timing.WaitForSeconds(duration);

            if (subtitle == null)
            {
                removalHandles.Remove(subtitle);
                yield break;
            }

            subtitles.Remove(subtitle);
            removalHandles.Remove(subtitle);

            subtitle.RectTransform.DOKill();

            Destroy(subtitle.gameObject);

            RepositionSubtitles();
        }
    }
}