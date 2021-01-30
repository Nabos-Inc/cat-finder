using UnityEngine;

namespace CatFinder
{
    [CreateAssetMenu(fileName = "new_characterData", menuName = "CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private string m_characterName = null;

        public string CharacterName { get => m_characterName; }
    }
}