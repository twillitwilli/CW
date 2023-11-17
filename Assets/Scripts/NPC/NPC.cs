using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField]
    TMP_Text _chatWindow;

    [SerializeField]
    bool _randomizeResponse;

    [SerializeField]
    string[] _chatResponses;

    public void Talk()
    {
        if (_randomizeResponse)
        {
            int randomResponse = Random.Range(0, _chatResponses.Length);
            _chatWindow.text = _chatResponses[randomResponse];
        }
    }
}
