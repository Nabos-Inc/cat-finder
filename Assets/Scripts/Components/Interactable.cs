using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CatFinder
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_onInteract = null;

        public void InvokeOnInteract()
        {
            m_onInteract?.Invoke();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            if (UIManager.Instance == null || UIManager.Instance.DialogueUI == null) return;

            UIManager.Instance.DialogueUI.ExecuteDialogue(dialogue);
        }
    }
}