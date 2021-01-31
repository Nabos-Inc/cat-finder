using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatFinder
{
    public class QuestUI : MonoBehaviour
    {
        [Header("Tabs")]
        [SerializeField] private RectTransform m_noQuestTab = null;
        [SerializeField] private RectTransform m_questTab = null;

        [Header("Quest Tab")]
        [SerializeField] private TextMeshProUGUI m_title = null;
        [SerializeField] private TextMeshProUGUI m_targetName = null;
        [SerializeField] private TextMeshProUGUI m_ownerName = null;
        [SerializeField] private TextMeshProUGUI m_description = null;
        [SerializeField] private RectTransform m_hintsTab = null;
        [SerializeField] private Image m_visualHintImage = null;
        [SerializeField] private Button m_audioHintBtn = null;

        public void Show()
        {
            gameObject.SetActive(true);

            Quest currentQuest = QuestController.Instance.CurrentQuest;

            if (currentQuest == null)
            {
                m_noQuestTab.gameObject.SetActive(true);
                return;
            }

            ShowQuestInfo(currentQuest);
        }

        private void ShowQuestInfo(Quest quest)
        {
            if (m_title != null)
            {
                m_title.text = quest.Title;
            }
            
            if (m_targetName != null)
            {
                m_targetName.text = quest.RequestedItem.PickableName;
            }

            if (m_ownerName != null)
            {
                m_ownerName.text = quest.Requester.CharacterName;
            }
            
            if (m_description != null)
            {
                m_description.text = quest.Description;
            }

            if (m_visualHintImage != null)
            {
                bool hasVisualHint = quest.VisualHint != null;
                m_visualHintImage.gameObject.SetActive(hasVisualHint);
                if (hasVisualHint)
                {
                    m_hintsTab.gameObject.SetActive(true);
                    m_visualHintImage.sprite = quest.VisualHint;
                }
            }

            if (m_audioHintBtn != null)
            {
                bool hasAudioHint = quest.AudioHint != null;
                m_audioHintBtn.gameObject.SetActive(hasAudioHint);
                if (hasAudioHint)
                {
                    m_hintsTab.gameObject.SetActive(true);
                }
            }

            m_questTab.gameObject.SetActive(true);
        }

        public void Hide()
        {
            m_hintsTab.gameObject.SetActive(false);
            m_noQuestTab.gameObject.SetActive(false);
            m_questTab.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}