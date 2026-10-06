using UnityEngine;
using System.Collections;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;

    [TextArea(2, 5)]
    public string subtitle;

    public AudioClip audioClip;
}

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private DialogueLine[] dialogueLines;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("Subtitles")]
    [SerializeField] private Subtitles subtitleManager;

    [Header("Timing")]
    [SerializeField] private float delayBetweenLines = 0.7f;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
            return;

        if (!other.CompareTag("Player"))
            return;

        hasTriggered = true;

        StartCoroutine(PlayDialogue());
    }

    private IEnumerator PlayDialogue()
    {
        foreach (DialogueLine line in dialogueLines)
        {
            // تنظیم صدا
            audioSource.clip = line.audioClip;

            // پخش صدا
            audioSource.Play();

            // نمایش زیرنویس
            subtitleManager.ShowSubtitle(
                line.speakerName,
                line.subtitle,
                audioSource
            );

            // صبر تا پایان صدا
            yield return new WaitForSeconds(line.audioClip.length);

            // فاصله بین دیالوگ‌ها
            yield return new WaitForSeconds(delayBetweenLines);
        }
    }
}