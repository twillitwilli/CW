using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    Sprite
        _fullHealth,
        _halfHeart,
        _emptyHealth;

    [SerializeField]
    Image[] _healthSprite;

    public void AdjustHealthDisplay(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            _healthSprite[i].gameObject.SetActive(true);

            if (currentHealth > i)
                _healthSprite[i].sprite = _fullHealth;

            else
                _healthSprite[i].sprite = _emptyHealth;
        }
    }
}
