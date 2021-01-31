using UnityEngine;
using UnityEngine.Events;

namespace CatFinder
{
    public class QuestChest : BaseInteractable
    {
        [SerializeField] private Quest m_quest = null;
        [SerializeField] protected UnityEvent m_onQuestActive = null;
        [SerializeField] protected UnityEvent m_onDefault = null;

        protected override void InternalInteract()
        {
            QuestController controller = QuestController.Instance;

            QuestStatus status = controller.GetQuestStatus(m_quest);

            if (status == QuestStatus.Active && m_actor.Inventory.Object != null)
            {
                m_onQuestActive?.Invoke();
            }
            else
            {
                m_onDefault?.Invoke();
            }
        }
    }
}