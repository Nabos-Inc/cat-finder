using UnityEngine;
using UnityEngine.InputSystem;

namespace CatFinder
{
    public class CharacterController : MonoBehaviour
    {
        private Movement m_movement = null;
        private LookAt2D m_lookAt = null;

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
    }
}