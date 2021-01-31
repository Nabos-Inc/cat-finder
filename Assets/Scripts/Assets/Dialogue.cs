using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    [CreateAssetMenu(fileName = "new_dialogue", menuName = "Dialogue/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] private List<DialogueAction> m_actions = null;

        public List<DialogueAction> Actions { get => m_actions; }
    }
}