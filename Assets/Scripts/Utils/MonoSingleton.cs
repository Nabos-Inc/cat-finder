using UnityEngine;

namespace CatFinder
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T m_instance = null;

        public static T Instance => m_instance;

        protected virtual void OnSingletonAwake() { }
        protected virtual void OnSingletonDestroy() { }

        private void Awake()
        {
            if (m_instance != null && m_instance != this)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this as T;
            OnSingletonAwake();
        }

        private void OnDestroy()
        {
            if (m_instance != null && m_instance == this)
            {
                OnSingletonDestroy();
            }
        }
    }
}