using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    public class QuestController : MonoSingleton<QuestController>
    {
        [SerializeField] private List<Quest> m_quests = null;

        private List<Quest> m_completedQuests = null;
        private Quest m_currentQuest = null;

        public Quest CurrentQuest { get => m_currentQuest; }

        protected override void OnSingletonAwake()
        {
            m_completedQuests = new List<Quest>();
        }

        public void StartQuest(Quest quest)
        {
            if (!CanStartQuest(quest)) return;

            m_currentQuest = quest;
        }

        private void CompleteQuest(Quest quest)
        {
            if (!CanCompleteQuest(quest)) return;

            m_completedQuests.Add(m_currentQuest);
            m_currentQuest = null;
        }

        public bool IsQuestComplete(Quest quest)
        {
            if (m_completedQuests == null) return false;

            return m_completedQuests.Contains(quest);
        }

        public bool CanStartQuest(Quest quest)
        {
            return m_currentQuest == null && !IsQuestComplete(quest);
        }

        public bool CanCompleteQuest(Quest quest)
        {
            return IsQuestActive(quest) && !IsQuestComplete(quest);
        }

        public bool IsQuestActive(Quest quest)
        {
            return m_currentQuest == quest;
        }

        public QuestStatus GetQuestStatus(Quest quest)
        {
            if (IsQuestComplete(quest)) return QuestStatus.Complete;

            if (IsQuestActive(quest)) return QuestStatus.Active;

            if (CanStartQuest(quest)) return QuestStatus.Initiable;

            return QuestStatus.None;
        }

        public void CompleteCurrentQuest()
        {
            CompleteQuest(m_currentQuest);
        }
    }

    public enum QuestStatus
    {
        None,
        Initiable,
        Active,
        Complete
    }
}
