using UnityEngine;

namespace CatFinder
{
    public abstract class BaseInteractable : MonoBehaviour
    {
        protected Actor m_actor = null;
        protected Actor m_starter = null;

        protected abstract void InternalInteract();

        private void Awake()
        {
            m_actor = GetComponent<Actor>();
        }

        public void InvokeOnInteract(Actor starter)
        {
            m_starter = starter;
            InternalInteract();
            m_starter = null;
        }

        public void StartDialogue(Dialogue dialogue)
        {
            if (UIManager.Instance == null || UIManager.Instance.DialogueUI == null) return;

            UIManager.Instance.DialogueUI.ExecuteDialogue(dialogue, m_starter, m_actor);
        }
    }
}