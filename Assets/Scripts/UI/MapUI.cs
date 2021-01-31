using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    public class MapUI : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}