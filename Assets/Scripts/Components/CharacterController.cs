using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatFinder
{
    public class CharacterController : MonoBehaviour
    {
        private Movement m_movement = null;
        private LookAt2D m_lookAt = null;
        private ContactCheck m_contactCheck = null;

        [SerializeField] private TextMeshProUGUI m_text = null;

        // Start is called before the first frame update
        void Awake()
        {
            m_movement = GetComponent<Movement>();
            m_lookAt = GetComponent<LookAt2D>();
            m_contactCheck = GetComponent<ContactCheck>();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_movement != null && m_movement.IsMoving())
            {
                if (m_contactCheck.CheckDirection(m_movement.Direction))
                {
                    m_movement.Stop();
                }
            }
        }

        private void OnMove(InputValue inputValue)
        {
            Vector2 direction = inputValue.Get<Vector2>();

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
            if (m_lookAt == null || m_contactCheck == null) return;

            Collider[] colliders = m_contactCheck.GetColliders(m_lookAt.Direction);
            if (colliders == null) return;

            foreach (var coll in colliders)
            {
                if (m_text == null) continue;

                m_text.text = $"Interacted with { coll.gameObject.name }";
            }
        }
    }
}