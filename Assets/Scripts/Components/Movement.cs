﻿using System;
using UnityEngine;

namespace CatFinder
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float m_speed = 1f;
        
        private Vector2 m_direction = Vector2.zero;

        public Vector2 Direction { get => m_direction; }

        private void Update()
        {
            if (m_direction == Vector2.zero) return;

            Vector3 currentPosition = transform.position;
            currentPosition += m_speed * Time.deltaTime * m_direction.ToXZVector3();
            transform.position = currentPosition;
        }

        public void Move(Vector2 direction)
        {
            m_direction = direction;
        }

        public bool IsMoving()
        {
            return m_direction != Vector2.zero;
        }

        public void Stop()
        {
            m_direction = Vector2.zero;
        }
    }
}