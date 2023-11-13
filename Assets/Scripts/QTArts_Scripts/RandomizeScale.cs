using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QTArts.Classes
{
    public class RandomizeScale : MonoBehaviour
    {
        [SerializeField]
        float
        _minScale,
        _maxScale;

        void Start()
        {
            float randomScale = Random.Range(_minScale, _maxScale);
            transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }
}
