using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CheckPlayerProgress : MonoBehaviour
{
    PlayerProgress _playerProgress;
    PlayerStats _playerStats;

    public enum CheckProgress
    {
        spear,
        sycthe,
        theForgottenScythe,
        magicGlove,
        magicKnifePouch,
        fireCystal,
        ghostStaff,
        bookOfTruth,
        gravityCrystal,
        portalCrystal,
        magicHourglass
    }

    [SerializeField]
    CheckProgress _checkWhichStat;

    [SerializeField]
    GameObject _itemIcon;

    private async void Start()
    {
        _playerProgress = Player.Instance.playerProgress;
        _playerStats = Player.Instance.playerStats;

        await Task.Delay(1000);

        UpdateProgress();
    }

    public void UpdateProgress()
    {
        switch (_checkWhichStat)
        {
            case CheckProgress.spear:

                if (_playerProgress.hasSpear)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.sycthe:

                if (_playerProgress.hasScythe)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.theForgottenScythe:

                if (_playerProgress.hasTheForgottenScythe)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.magicGlove:

                if (_playerProgress.hasMagicGlove)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.magicKnifePouch:

                if (_playerProgress.hasMagicKnifePouch)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.fireCystal:

                if (_playerProgress.hasFireCrystal)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.ghostStaff:

                if (_playerProgress.hasGhostStaff)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.bookOfTruth:

                if (_playerProgress.hasBookOfTruth)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.gravityCrystal:

                if (_playerProgress.hasGravityCrystal)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.portalCrystal:

                if (_playerProgress.hasPortalCrystal)
                    _itemIcon.SetActive(true);

                break;

            case CheckProgress.magicHourglass:

                if (_playerProgress.hasMagicHourglass)
                    _itemIcon.SetActive(true);

                break;
        }
    }
}
