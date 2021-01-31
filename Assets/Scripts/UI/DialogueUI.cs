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
        private Actor m_starter = null;
        private Actor m_receiver = null;

        private void ShowDialogue(string characterName, string text, AudioClip sfx, List<AdditionalAction> additionalActions)
        {
            if (m_characterLabel != null)
            {
                m_characterLabel.text = characterName;
            }

            if (m_dialogueArea != null)
            {
                m_dialogueArea.text = text;
            }

            if (sfx != null)
            {
                AppManager.Instance.AudioController.PlaySfxClip(sfx);
            }

            ExecuteAdditionalActions(additionalActions);
        }

       private void ExecuteAdditionalActions(List<AdditionalAction> additionalActions)
        {
            if (additionalActions == null) return;

            int size = additionalActions.Count;
            for (int i = 0; i < size; i++)
            {
                AdditionalAction action = additionalActions[i];
                switch (action)
                {
                    case AdditionalAction.GiveObject:
                        {
                            m_starter.GiveObject(m_receiver);
                            break;
                        }
                    case AdditionalAction.TakeObject:
                        {
                            m_receiver.GiveObject(m_starter);
                            break;
                        }
                    case AdditionalAction.CompleteQuest:
                        {
                            QuestController.Instance.CompleteCurrentQuest();
                            break;
                        }
                    default:
                        {
                            Debug.LogWarning("Additional action not supported.");
                            break;
                        }
                }
            }
        }

        private void ShowCurrentDialogueAction()
        {
            DialogueAction action = m_dialogue.Actions[m_currentActionIdx];
            ShowDialogue(action.Character, action.Text, action.Sfx, action.AdditionalActions);
        }

        public void ExecuteDialogue(Dialogue dialogue, Actor starter, Actor receiver)
        {
            m_starter = starter;
            m_receiver = receiver;

            InputController.Instance.OnFireEvent += ContinueDialogue;

            gameObject.SetActive(true);
            m_dialogue = dialogue;
            m_currentActionIdx = 0;

            ShowCurrentDialogueAction();
        }

        public bool IsActive()
        {
            return gameObject.activeSelf;
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

            m_starter = null;
            m_receiver = null;
        }
    }
}