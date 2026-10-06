using UnityEngine;

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
    public DialogueLine[] dialogueLines;

    public AudioSource audioSource;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
            return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            StartCoroutine(PlayDialogue());
        }
    }

    private System.Collections.IEnumerator PlayDialogue()
    {
        foreach (DialogueLine line in dialogueLines)
        {
            Debug.Log(line.speakerName + ": " + line.subtitle);

            audioSource.clip = line.audioClip;
            audioSource.Play();

            yield return new WaitForSeconds(line.audioClip.length);
        }
    }
}