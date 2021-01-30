using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    public class LookAt2D : MonoBehaviour
    {
        [SerializeField] private Transform m_target = null;
        [SerializeField] private bool m_facingRight = true;

        private Vector2 m_direction = Vector2.zero;

        public Vector2 Direction { get => m_direction; }

        private void Awake()
        {
            SetDirection(m_facingRight);
        }

        private void SetDirection(bool facingRight)
        {
            m_direction = facingRight ? Vector2.right : Vector2.left;
        }

        public void LookAt(Vector2 direction)
        {
            if (direction.x == 0) return;

            bool negative = Mathf.Sign(direction.x) == -1;
            bool zeroAngle = (m_facingRight && !negative) || (!m_facingRight && negative);
            SetDirection(!negative);

            Vector3 currentRot = m_target.rotation.eulerAngles;
            currentRot.y = zeroAngle ? 0f : 180f;
            m_target.rotation = Quaternion.Euler(currentRot);
        }
    }
}