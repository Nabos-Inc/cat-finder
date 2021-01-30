using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    public class Actor : MonoBehaviour
    {
        [SerializeField] private Inventory m_inventory = null;

        public Inventory Inventory { get => m_inventory; }

        public bool GiveObject(Actor toActor)
        {
            if (!m_inventory.CanGiveObject()) return false;

            return toActor.m_inventory.ReceiveObject(m_inventory);
        }
    }
}