using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    public class LookAt2D : MonoBehaviour
    {
        [SerializeField] private Transform m_target = null;
        [SerializeField] private bool m_facingRight = true;

        public void LookAt(Vector2 direction)
        {
            if (direction.x == 0) return;

            bool negative = Mathf.Sign(direction.x) == -1;
            bool zeroAngle = (m_facingRight && !negative) || (!m_facingRight && negative);

            Vector3 currentRot = m_target.rotation.eulerAngles;
            currentRot.y = zeroAngle ? 0f : 180f;
            m_target.rotation = Quaternion.Euler(currentRot);
        }
    }
}