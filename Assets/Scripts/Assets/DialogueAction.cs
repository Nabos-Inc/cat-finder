using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    [System.Serializable]
    public class DialogueAction
    {
        [SerializeField] private CharacterData m_character = null;
        [SerializeField, TextArea] private string m_text = null;
        [SerializeField] private AudioClip m_sfx = null;
        [SerializeField] private List<AdditionalAction> m_additionalActions = null;

        public string Character { get => m_character?.CharacterName; }
        public string Text { get => m_text; }
        public AudioClip Sfx { get => m_sfx; }
        public List<AdditionalAction> AdditionalActions { get => m_additionalActions; }
    }

    public enum AdditionalAction
    {
        None,
        TakeObject,
        GiveObject,
        CompleteQuest
    }
}