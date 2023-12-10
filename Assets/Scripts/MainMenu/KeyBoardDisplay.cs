using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyBoardDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text _text;

    [SerializeField]
    GameObject
        _upperCase,
        _lowerCase;

    bool _isLowerCase;

    public void NewInput(string input)
    {
        switch (input)
        {
            case "SwitchCase":

                SwitchCaseLetters();

                break;

            case "BackSpace":

                _text.text = "";

                break;

            case "Enter":

                Player.Instance.playerName = _text.text;

                SaveManager.Instance.LoadData(GameManager.Instance.saveFile);

                break;

            default:

                _text.text += input;

                break;
        }
    }

    private void SwitchCaseLetters()
    {
        if (!_isLowerCase)
        {
            _upperCase.SetActive(false);
            _lowerCase.SetActive(true);
            _isLowerCase = true;
        }

        else
        {
            _upperCase.SetActive(true);
            _lowerCase.SetActive(false);
            _isLowerCase = false;
        }
    }
}
