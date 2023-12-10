using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField]
    KeyBoardDisplay _keyboardDisplay;

    public void ButtonSelected(string input)
    {
        _keyboardDisplay.NewInput(input);
    }
}
