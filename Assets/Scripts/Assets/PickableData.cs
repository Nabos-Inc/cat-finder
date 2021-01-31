using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    [CreateAssetMenu(fileName = "new_pickableData", menuName = "PickableData")]
    public class PickableData : ScriptableObject
    {
        [SerializeField] private string m_pickableName = null;
        [SerializeField] private Sprite m_image = null;

        public string PickableName { get => m_pickableName; }
        public Sprite Image { get => m_image; }
    }
}