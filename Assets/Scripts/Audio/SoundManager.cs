using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource possessSource;
    public AudioClip[] audioClips;

    public static SoundManager instance = null;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void PlaySFX(AudioClip clip, AudioSource source, float pitchVariation)
    {
        source.pitch = pitchVariation;
        source.PlayOneShot(clip);
    }
}
