using UnityEngine;

namespace CatFinder
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip m_clip = null;

        // Start is called before the first frame update
        void Awake()
        {
            if (m_clip == null) return;

            AppManager.Instance.AudioController.PlayMusic(m_clip);
        }
    }
}