using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class MusicManager : MonoSingleton<MusicManager>
{
    [SerializeField]
    AudioSource _musicPlayer;

    [SerializeField]
    AudioClip[] _musicClips;

    public float _currentVolume { get; private set; }

    public void ChangeMusicClip(int whichClip)
    {
        _musicPlayer.clip = _musicClips[whichClip];
        _musicPlayer.Play();
    }

    public void AdjustInsideVolume()
    {
        _musicPlayer.volume /= 2;
    }

    public void ReturnToOutsideVolume()
    {
        _musicPlayer.volume *= 2;
    }

    public void AdjustMusicVolmue(float adjustmentValue)
    {
        _currentVolume += adjustmentValue;

        if (_currentVolume > 1)
            _currentVolume = 1;

        else if (_currentVolume < 0)
            _currentVolume = 0;

        _musicPlayer.volume = _currentVolume;
    }
}
