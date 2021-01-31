using UnityEngine;

namespace CatFinder
{
    public class Actor : MonoBehaviour
    {
        [SerializeField] private Inventory m_inventory = null;

        public Inventory Inventory { get => m_inventory; }

        public bool GiveObject(Actor toActor)
        {
            if (!m_inventory.CanGiveObject()) return false;

            bool received = toActor.m_inventory.ReceiveObject(m_inventory);

            if (received)
            {
                m_inventory.InvokeOnObjectGiven();
            }

            return received;
        }

        public void UpdateInventoryUIWithContent()
        {
            UIManager.Instance.InventoryUI.SetContent(m_inventory);
        }
    }
}