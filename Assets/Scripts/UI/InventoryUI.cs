using UnityEngine;
using UnityEngine.UI;

namespace CatFinder
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Image m_content = null;

        public void SetContent(Inventory inventory)
        {
            PickableData currentItem = inventory.Object;
            bool hasObject = currentItem != null;
            m_content.sprite = hasObject ? currentItem.Image : null;
            gameObject.SetActive(hasObject);
        }
    }
}

