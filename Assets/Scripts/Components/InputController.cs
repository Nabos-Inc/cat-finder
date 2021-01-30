using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatFinder
{
    public class InputController : MonoSingleton<InputController>
    {
        public event Action<Vector2> OnMoveEvent;
        public event Action OnFireEvent;

        private void OnMove(InputValue inputValue)
        {
            Vector2 direction = inputValue.Get<Vector2>();

            OnMoveEvent?.Invoke(direction);
        }

        private void OnFire()
        {
            OnFireEvent?.Invoke();
        }
    }
}