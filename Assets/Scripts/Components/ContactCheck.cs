using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    public class ContactCheck : MonoBehaviour
    {
        private readonly static List<Vector2> kAllCheckDirections = new List<Vector2>()
        {
            Vector2.up, Vector2.one, Vector2.right, new Vector2(1, -1), 
            Vector2.down, Vector2.one * -1, Vector2.left, new Vector2(-1, 1)
        };

        [SerializeField] private float m_yOffset = 0.5f;
        [SerializeField] private float m_sphereRadius = 0.5f;
        [SerializeField] private float m_checkDistance = 0.75f;

        [Header("Debug")]
        [SerializeField] private Color m_lineColor = Color.red;
        [SerializeField] private float m_lineDuraction = 3f;

        public Collider[] GetColliders(Vector2 direction)
        {
            Vector3 center = transform.position;
            center.y += m_yOffset;
            center += direction.ToXZVector3() * m_checkDistance;

            Collider[] colliders = Physics.OverlapSphere(center, m_sphereRadius);

#if UNITY_EDITOR
            DrawDebugLine(center, new Vector3(0f, 0f, 1f));
            DrawDebugLine(center, new Vector3(0f, 0f, -1f));
            DrawDebugLine(center, Vector3.left);
            DrawDebugLine(center, Vector3.right);
#endif

            return colliders;
        }

        public bool CheckDirection(Vector2 direction)
        {
            Collider[] colliders = GetColliders(direction);
            return colliders != null && colliders.Length > 0;
        }

#if UNITY_EDITOR
        private void DrawDebugLine(Vector3 position, Vector3 direction)
        {
            Debug.DrawLine(position, position + (direction * m_sphereRadius), m_lineColor, m_lineDuraction);
        }
#endif
    }

}