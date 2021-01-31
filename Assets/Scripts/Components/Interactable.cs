using UnityEngine;
using UnityEngine.Events;

namespace CatFinder
{
    [RequireComponent(typeof(Actor))]
    public class Interactable : BaseInteractable
    {
        [SerializeField] protected UnityEvent m_onInteract = null;

        protected override void InternalInteract()
        {
            m_onInteract?.Invoke();
        }
    }
}