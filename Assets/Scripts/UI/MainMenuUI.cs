using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatFinder
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private RectTransform m_creditsTab = null;

        private SelectableUI[] m_selectables = null;

        private void Awake()
        {
            m_selectables = GetComponentsInChildren<SelectableUI>(true);

            EventSystem.current.SetSelectedGameObject(null);
            StartCoroutine(ShowCo());
        }

        private IEnumerator ShowCo()
        {
            yield return null;

            EventSystem.current.SetSelectedGameObject(m_selectables[0].gameObject);
        }

        public void HideContentTabs()
        {
            m_creditsTab.gameObject.SetActive(false);
        }

        public void ShowCreditsTab()
        {
            m_creditsTab.gameObject.SetActive(true);
        }

        public void CloseApp()
        {
            AppManager.Instance.Quit();
        }

        public void StartGame()
        {
            AppManager.Instance.LoadGameScene();
        }
    }
}