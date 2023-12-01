using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    Player _player;

    [SerializeField]
    TMP_Text _chatWindow;

    [SerializeField]
    bool _randomizeResponse;

    [SerializeField]
    string[] _chatResponses;

    [SerializeField]
    GameObject
        _chatBubble,
        _innBarrier;

    private void Start()
    {
        _player = Player.Instance;
    }

    private void Update()
    {
        if (_chatBubble.activeSelf && Vector3.Distance(_player.transform.position, transform.position) > 5)
            _chatBubble.SetActive(false);
    }

    public void Talk()
    {
        if (_randomizeResponse)
        {
            int randomResponse = Random.Range(0, _chatResponses.Length);
            _chatWindow.text = _chatResponses[randomResponse];
        }

        else
        {
            _chatBubble.SetActive(true);
        }
    }

    public void BuyItem()
    {
        _chatWindow.text = _chatResponses[1];

        _innBarrier.SetActive(false);
    }
}
