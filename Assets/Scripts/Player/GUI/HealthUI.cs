using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    PlayerStats _playerStats;

    [SerializeField]
    Sprite
        _fullHealth,
        _emptyHealth;

    [SerializeField]
    Image[] _healthSprite;

    public void AdjustHealthDisplay()
    {
        for (int i = 0; i < _playerStats.maxHealth; i++)
        {
            _healthSprite[i].gameObject.SetActive(true);

            if (_playerStats.Health > i)
                _healthSprite[i].sprite = _fullHealth;

            else
                _healthSprite[i].sprite = _emptyHealth;
        }
    }
}
