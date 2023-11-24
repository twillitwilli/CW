using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QTArts.Classes
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
