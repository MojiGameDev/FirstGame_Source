using UnityEngine;

public class PlayClickSound : MonoBehaviour
{
    public AudioClip clip;

    public void Play()
    {
        AudioManager.Instance.PlaySFX(clip);
    }
}