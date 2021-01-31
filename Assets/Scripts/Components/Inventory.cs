using UnityEngine;

namespace CatFinder
{
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private PickableData m_object = null;

        public PickableData Object { get => m_object; }

        public bool CanReceiveObject()
        {
            return m_object == null;
        }

        public bool CanGiveObject()
        {
            return m_object != null;
        }

        public bool ReceiveObject(Inventory fromInventory)
        {
            if (!CanReceiveObject()) return false;

            m_object = fromInventory.m_object;
            fromInventory.m_object = null;

            return true;
        }
    }
}