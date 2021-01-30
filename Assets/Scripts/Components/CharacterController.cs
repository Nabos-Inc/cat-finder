using UnityEngine;

namespace CatFinder
{
    public class CharacterController : MonoBehaviour
    {
        private const string kHorizontalAxis = "Horizontal";
        private const string kVerticalAxis = "Vertical";

        private Movement m_movement = null;
        private Vector2 m_movementDir = Vector2.zero;

        // Start is called before the first frame update
        void Awake()
        {
            m_movement = GetComponent<Movement>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            if (m_movement == null) return;
            
            float xInput = Input.GetAxis(kHorizontalAxis);
            float zInput = Input.GetAxis(kVerticalAxis);

            m_movementDir.Set(xInput, zInput);

            m_movement.Move(m_movementDir);
        }
    }
}