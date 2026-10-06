using System.Collections;
using TMPro;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    [SerializeField] private GameObject subtitleBox;
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private float fadeDuration = 0.25f;

    private Coroutine currentSubtitle;

    private void Start()
    {
        subtitleBox.SetActive(false);
        canvasGroup.alpha = 0f;
    }

    public void ShowSubtitle(
        string speaker,
        string dialogue,
        AudioSource audioSource)
    {
        if (currentSubtitle != null)
            StopCoroutine(currentSubtitle);

        currentSubtitle = StartCoroutine(
            SubtitleRoutine(speaker, dialogue, audioSource)
        );
    }

    private IEnumerator SubtitleRoutine(
        string speaker,
        string dialogue,
        AudioSource audioSource)
    {
        subtitleText.text =
            $"<color=#FFD43B>{speaker}:</color> {dialogue}";

        subtitleBox.SetActive(true);

        // Fade In
        yield return Fade(0f, 3f);

        // تا وقتی صدا در حال پخش است صبر کن
        while (audioSource != null && audioSource.isPlaying)
        {
            yield return null;
        }

        // Fade Out
        yield return Fade(3f, 0f);

        subtitleBox.SetActive(false);

        currentSubtitle = null;
    }

    private IEnumerator Fade(float from, float to)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float t = time / fadeDuration;

            canvasGroup.alpha = Mathf.Lerp(from, to, t);

            yield return null;
        }

        canvasGroup.alpha = to;
    }
}