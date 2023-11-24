using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QTArts.AbstractClasses;

public class OnScreenTextDisplayer : MonoSingleton<OnScreenTextDisplayer>
{
    [SerializeField]
    TMP_Text _textDisplay;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    string[] _text;

    public void ChangeText(int whichText)
    {
        _textDisplay.text = _text[whichText];
    }

    public void PlayFadeIn()
    {
        _animator.Play("FadeIn");
    }

    public void PlayFadeOut()
    {
        _animator.Play("FadeOut");
    }

    public void AnimationDone()
    {
        CameraController.Instance.ReturnToDefaultZoom("CotfalVillage");

        gameObject.SetActive(false);
    }
}
