using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace CatFinder
{
    public class SelectableUI : MonoBehaviour, ISelectHandler
    {
        [SerializeField] private UnityEvent m_onSelected = null;

        public void OnSelect(BaseEventData eventData)
        {
            Debug.Log($"Selected { gameObject.name }.");
            m_onSelected?.Invoke();
        }
    }
}