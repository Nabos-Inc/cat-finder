using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    [CreateAssetMenu(fileName = "new_pickableData", menuName = "PickableData")]
    public class PickableData : ScriptableObject
    {
        [SerializeField] private Sprite m_image = null;
    }
}