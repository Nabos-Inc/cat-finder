using UnityEngine;

namespace CatFinder
{
    public class UIManager : MonoSingleton<UIManager>
    {
        private DialogueUI m_dialogueUI = null;

        protected override void OnSingletonAwake()
        {
            m_dialogueUI = GetComponentInChildren<DialogueUI>(true);
        }

        public DialogueUI DialogueUI { get => m_dialogueUI; }
    }
}