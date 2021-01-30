using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFinder
{
    [System.Serializable]
    public class SerializableDictionary<T> : List<T> where T : class, new() 
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}