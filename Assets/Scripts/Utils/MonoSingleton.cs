using UnityEngine;

namespace CatFinder
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        [SerializeField] private bool m_dontDestroyOnLoad = false;

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

            if (m_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }

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