using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatFinder
{
    public class PauseMenuUI : MonoBehaviour
    {
        private QuestUI m_questUI = null;
        private MapUI m_mapUI = null;
        private SelectableUI[] m_selectables = null;

        private void Awake()
        {
            m_questUI = GetComponentInChildren<QuestUI>(true);
            m_mapUI = GetComponentInChildren<MapUI>(true);
            m_selectables = GetComponentsInChildren<SelectableUI>(true);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);

            StartCoroutine(ShowCo());
        }

        private IEnumerator ShowCo()
        {
            yield return null;
            
            EventSystem.current.SetSelectedGameObject(m_selectables[0].gameObject);
        }

        public void Hide()
        {
            HideContentTabs();
            gameObject.SetActive(false);
        }

        public void HideContentTabs()
        {
            m_questUI.Hide();
            m_mapUI.Hide();
        }

        public void ShowQuestUI()
        {
            HideContentTabs();
            m_questUI.Show();
        }

        public void ShowMapUI()
        {
            HideContentTabs();
            m_mapUI.Show();
        }

        public void CloseApp()
        {
            Debug.LogWarning("Closing app.");
        }

        public bool IsActive()
        {
            return gameObject.activeInHierarchy;
        }
    }
}