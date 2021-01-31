using UnityEngine;
using UnityEngine.Events;

namespace CatFinder
{
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private PickableData m_object = null;

        [SerializeField] private UnityEvent m_onObjectReceived = null;
        [SerializeField] private UnityEvent m_onObjectGiven = null;

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

            m_onObjectReceived?.Invoke();

            return true;
        }

        public void InvokeOnObjectGiven()
        {
            m_onObjectGiven?.Invoke();
        }
    }
}