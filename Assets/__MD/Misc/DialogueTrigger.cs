using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private string speakerName;

    [TextArea(2, 5)]
    [SerializeField] private string dialogueText;

    [Header("References")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Subtitles subtitleUI;

    [Header("Settings")]
    [SerializeField] private bool playOnlyOnce = true;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("TRIGGER ENTERED: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED!");
        }
        if (!other.CompareTag("Player"))
            return;

        if (playOnlyOnce && hasPlayed)
            return;

        hasPlayed = true;

        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is missing.", this);
            return;
        }

        if (audioSource.clip == null)
        {
            Debug.LogWarning("AudioClip is missing.", this);
            return;
        }

        // Play audio
        audioSource.Play();

        // Show subtitle
        if (subtitleUI != null)
        {
            subtitleUI.ShowSubtitle(
                speakerName,
                dialogueText,
                audioSource
            );
        }
    }
}