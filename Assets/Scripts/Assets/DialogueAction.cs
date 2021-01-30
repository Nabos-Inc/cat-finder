using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    [System.Serializable]
    public class DialogueAction
    {
        [SerializeField] private CharacterData m_character = null;
        [SerializeField, TextArea] private string m_text = null;

        public string Character { get => m_character.CharacterName; }
        public string Text { get => m_text; }
    }
}