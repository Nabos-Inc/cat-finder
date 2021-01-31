using UnityEngine;

namespace CatFinder
{
    public class UIManager : MonoSingleton<UIManager>
    {
        private DialogueUI m_dialogueUI = null;
        private PauseMenuUI m_pauseUI = null;

        protected override void OnSingletonAwake()
        {
            m_dialogueUI = GetComponentInChildren<DialogueUI>(true);
            m_pauseUI = GetComponentInChildren<PauseMenuUI>(true);
        }

        private void Start()
        {
            InputController.Instance.OnPauseEvent += OnPause;
        }

        private void OnPause()
        {
            if (!m_pauseUI.IsActive())
            {
                m_pauseUI.Show();
            }
        }

        public DialogueUI DialogueUI { get => m_dialogueUI; }
        public PauseMenuUI PauseUI { get => m_pauseUI; }

        protected override void OnSingletonDestroy()
        {
            InputController.Instance.OnPauseEvent -= OnPause;
        }
    }
}