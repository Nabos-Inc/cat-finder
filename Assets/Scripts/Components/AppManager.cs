using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatFinder
{
    public class AppManager : MonoSingleton<AppManager>
    {
        [SerializeField] RectTransform m_loadingUI = null;
        [SerializeField] int m_mainMenuSceneIdx = 1;
        [SerializeField] int m_gameSceneIdx = 2;
        [SerializeField] bool m_loadMainMenuOnStart = true;

        private AudioController m_audioController = null;

        public AudioController AudioController { get => m_audioController; }

        // Start is called before the first frame update
        protected override void OnSingletonAwake()
        {
            m_audioController = GetComponentInChildren<AudioController>();

            SceneManager.activeSceneChanged += HideLoadingUI;

            if (m_loadMainMenuOnStart)
            {
                LoadMainMenu();
            }
            else
            {
                HideLoadingUI();
            }
        }

        public void LoadMainMenu()
        {
            StartCoroutine(LoadScene(m_mainMenuSceneIdx));
        }

        public void LoadGameScene()
        {
            StartCoroutine(LoadScene(m_gameSceneIdx));
        }

        private IEnumerator LoadScene(int index)
        {
            ShowLoadingUI();
            m_audioController.StopAll();

            yield return null;

            SceneManager.LoadSceneAsync(index);
        }

        private void ShowLoadingUI()
        {
            m_loadingUI.gameObject.SetActive(true);
        }

        private void HideLoadingUI()
        {
            m_loadingUI.gameObject.SetActive(false);
        }

        private void HideLoadingUI(Scene arg0, Scene arg1)
        {
            if (arg1.buildIndex == 0) return;

            HideLoadingUI();
        }

        public void Quit()
        {
            Application.Quit();
        }

        protected override void OnSingletonDestroy()
        {
            SceneManager.activeSceneChanged -= HideLoadingUI;
        }
    }
}