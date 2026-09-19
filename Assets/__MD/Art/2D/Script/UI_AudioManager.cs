using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton
    public AudioSource sfxSource;       // برای صداهای کوتاه مثل کلیک و هاور

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // تا بین صحنه‌ها حفظ شود
        }
        else
        {
            Destroy(gameObject); // اگر یک AudioManager دیگر باشد، حذف شود
        }
    }

    // پخش یک صدا
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }
}