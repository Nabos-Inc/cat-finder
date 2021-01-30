using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CatFinder
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_characterLabel = null;
        [SerializeField] private TextMeshProUGUI m_dialogueArea = null;

        private Dialogue m_dialogue = null;
        private int m_currentActionIdx = -1;

        private void ShowDialogue(string characterName, string text)
        {
            if (m_characterLabel != null)
            {
                m_characterLabel.text = characterName;
            }

            if (m_dialogueArea != null)
            {
                m_dialogueArea.text = text;
            }
        }

        private void ShowCurrentDialogueAction()
        {
            DialogueAction action = m_dialogue.Actions[m_currentActionIdx];
            ShowDialogue(action.Character, action.Text);
        }

        public void ExecuteDialogue(Dialogue dialogue)
        {
            InputController.Instance.OnFireEvent += ContinueDialogue;

            gameObject.SetActive(true);
            m_dialogue = dialogue;
            m_currentActionIdx = 0;

            ShowCurrentDialogueAction();
        }

        public bool IsDialogueActive()
        {
            return m_currentActionIdx > -1;
        }

        public void ContinueDialogue()
        {
            m_currentActionIdx++;
            if (m_currentActionIdx < m_dialogue.Actions.Count)
            {
                ShowCurrentDialogueAction();
                return;
            }

            Hide();
        }

        private void Hide()
        {
            InputController.Instance.OnFireEvent -= ContinueDialogue;

            m_currentActionIdx = -1;
            m_dialogue = null;
            gameObject.SetActive(false);
        }
    }
}