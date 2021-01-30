using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatFinder
{
    public class CharacterController : MonoBehaviour
    {
        private Movement m_movement = null;
        private LookAt2D m_lookAt = null;

        [SerializeField] private TextMeshProUGUI m_text = null;

        // Start is called before the first frame update
        void Awake()
        {
            m_movement = GetComponent<Movement>();
            m_lookAt = GetComponent<LookAt2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMove(InputValue inputValue)
        {
            Vector2 direction = inputValue.Get<Vector2>();

            if (m_movement != null)
            {
                m_movement.Move(direction);
            }

            if (m_lookAt != null)
            {
                m_lookAt.LookAt(direction);
            }
        }

        private void OnFire()
        {
            if (m_lookAt == null) return;

            Vector3 currentPos = transform.position;
            currentPos.y += 0.5f;
            currentPos += m_lookAt.Direction.ToXZVector3() * 0.75f;

            Collider[] colliders = Physics.OverlapSphere(currentPos, 0.5f);
            if (colliders == null) return;

            foreach (var coll in colliders)
            {
                if (m_text == null) continue;

                m_text.text = $"Interacted with { coll.gameObject.name }";
            }
        }
    }
}