using UnityEngine;

namespace CatFinder
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float m_speed = 1f;

        public void Move(Vector2 direction)
        {
            Vector3 currentPosition = transform.position;
            currentPosition += m_speed * direction.ToXZVector3();
            transform.position = currentPosition;
        }
    }
}