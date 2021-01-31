using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatFinder
{
    [RequireComponent(typeof(Actor))]
    public class CharacterController : MonoBehaviour
    {
        private Actor m_actor = null;
        private Movement m_movement = null;
        private LookAt2D m_lookAt = null;
        private ContactCheck m_contactCheck = null;

        // Start is called before the first frame update
        void Awake()
        {
            m_movement = GetComponent<Movement>();
            m_lookAt = GetComponent<LookAt2D>();
            m_contactCheck = GetComponent<ContactCheck>();
            m_actor = GetComponent<Actor>();
        }

        private void Start()
        {
            InputController.Instance.OnMoveEvent += OnMove;
            InputController.Instance.OnFireEvent += OnFire;
        }

        private void OnDestroy()
        {
            InputController.Instance.OnMoveEvent -= OnMove;
            InputController.Instance.OnFireEvent -= OnFire;
        }

        // Update is called once per frame
        void Update()
        {
            if (m_movement != null && m_movement.IsMoving())
            {
                if (m_contactCheck.CheckDirection(m_movement.Direction) || !CanMove())
                {
                    m_movement.Stop();
                }
            }
        }

        private void OnMove(Vector2 direction)
        {
            if (!CanMove()) return;

            bool inContact = m_contactCheck != null && direction != Vector2.zero && m_contactCheck.CheckDirection(direction);

            if (m_movement != null)
            {
                m_movement.Move(!inContact ? direction : Vector2.zero);
            }

            if (m_lookAt != null)
            {
                m_lookAt.LookAt(direction);
            }
        }

        private void OnFire()
        {
            if (m_lookAt == null || m_contactCheck == null || !CanInteract()) return;

            Collider[] colliders = m_contactCheck.GetColliders(m_lookAt.Direction);
            if (colliders == null) return;

            int size = colliders.Length;
            for (int i = 0; i < size; i++)
            {
                BaseInteractable interactable = colliders[i].gameObject.GetComponent<BaseInteractable>();
                if (interactable != null)
                {
                    interactable.InvokeOnInteract(m_actor);
                }
            }
        }

        private bool CanInteract()
        {
            return !UIManager.Instance.DialogueUI.IsDialogueActive();
        }

        private bool CanMove()
        {
            return !UIManager.Instance.DialogueUI.IsDialogueActive();
        }
    }
}