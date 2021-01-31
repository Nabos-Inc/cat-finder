using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatFinder
{
    public class InputController : MonoSingleton<InputController>
    {
        public event Action<Vector2> OnMoveEvent;
        public event Action OnFireEvent;
        public event Action OnPauseEvent;

        private void OnMove(InputValue inputValue)
        {
            Vector2 direction = inputValue.Get<Vector2>();

            OnMoveEvent?.Invoke(direction);
        }

        private void OnFire()
        {
            OnFireEvent?.Invoke();
        }

        private void OnPause()
        {
            OnPauseEvent?.Invoke();
        }
    }
}