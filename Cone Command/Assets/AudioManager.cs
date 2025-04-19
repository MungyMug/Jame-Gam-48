using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource m_Source;
    [SerializeField] AudioSource SFX_Source;

    public AudioClip background;
    public AudioClip enemyattack;
    public AudioClip playerattack;
    public AudioClip block;
    public AudioClip playerhit;
    public AudioClip enemyhit;
    public AudioClip carhonk;
    public AudioClip whalesplash;
    public AudioClip whalesound;
    public AudioClip gameOver;

    private void Start()
    {
        m_Source.clip = background;
        m_Source.Play();
    }

    public void PlaySFX(AudioClip SFX)
    {
        SFX_Source.PlayOneShot(SFX);
    }

    public void PlaySFX(AudioClip SFX, float volume)
    {
        SFX_Source.volume = volume;
        SFX_Source.PlayOneShot(SFX);
    }
}
