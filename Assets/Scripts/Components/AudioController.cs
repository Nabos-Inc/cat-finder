using UnityEngine;

namespace CatFinder
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource m_musicSource = null;
        [SerializeField] private AudioSource m_sfxSource = null;

        public void PlaySfxClip(AudioClip clip)
        {
            m_sfxSource.clip = clip;
            m_sfxSource.Play();
        }

        public void PlayMusic(AudioClip clip)
        {
            m_musicSource.clip = clip;
            m_musicSource.Play();
        }

        public void StopMusic()
        {
            m_musicSource.Stop();
        }

        public void StopSfx()
        {
            m_sfxSource.Stop();
        }

        public void StopAll()
        {
            StopMusic();
            StopSfx();
        }
    }
}