﻿using UnityEngine;

namespace CatFinder
{
    [CreateAssetMenu(fileName = "new_quest", menuName = "Quest")]
    public class Quest : ScriptableObject
    {
        [SerializeField] private CharacterData m_requester = null;
        [SerializeField] private PickableData m_requestedItem = null;
        [SerializeField] private string m_title = null;
        [SerializeField, TextArea] private string m_description = null;
        [SerializeField] private Sprite m_visualHint = null;
        [SerializeField] private AudioClip m_audioHint = null;

        public CharacterData Requester { get => m_requester; }
        public PickableData RequestedItem { get => m_requestedItem; }
        public string Title { get => m_title; }
        public string Description { get => m_description; }
        public Sprite VisualHint { get => m_visualHint; }
        public AudioClip AudioHint { get => m_audioHint; }

        public bool CanBeComplete(Actor actor)
        {
            return actor.Inventory.Object == m_requestedItem;
        }
    }
}