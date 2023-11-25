using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text _text;

    public void UpdateGoldDisplay(int currentGold)
    {
        _text.text = "$" + currentGold;
    }
}
