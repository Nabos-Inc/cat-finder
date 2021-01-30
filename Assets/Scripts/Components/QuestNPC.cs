using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CatFinder
{
    public class QuestNPC : Interactable
    {
        [SerializeField] private Quest m_quest = null;
        [SerializeField] protected UnityEvent m_onQuestNoInitiable = null;
        [SerializeField] protected UnityEvent m_onQuestStart = null;
        [SerializeField] protected UnityEvent m_onQuestActive = null;
        [SerializeField] protected UnityEvent m_onQuestFinish = null;
        [SerializeField] protected UnityEvent m_onQuestComplete = null;

        protected override void InternalInteract()
        {
            QuestController controller = QuestController.Instance;

            QuestStatus status = controller.GetQuestStatus(m_quest);

            switch (status)
            {
                case QuestStatus.Initiable:
                    {
                        controller.StartQuest(m_quest);
                        m_onQuestStart?.Invoke();
                        break;
                    }
                case QuestStatus.Active:
                    {
                        if (m_quest.CanBeComplete(m_starter))
                        {
                            m_onQuestFinish?.Invoke();
                        }
                        else
                        {
                            m_onQuestActive?.Invoke();
                        }
                        break;
                    }
                case QuestStatus.Complete:
                    {
                        m_onQuestComplete?.Invoke();
                        break;
                    }
                default:
                    {
                        m_onQuestNoInitiable?.Invoke();
                        break;
                    }
            }
        }
    }
}

