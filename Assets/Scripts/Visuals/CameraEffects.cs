using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    Player _player;

    public enum Effects
    {
        quickSceneChangeExpand,
        quickSceneChangeCollapse
    }

    [SerializeField]
    GameObject[] effect;

    private void Start()
    {
        _player = Player.Instance;
    }

    public void ChangeCameraEffect(Effects effects)
    {
        switch (effects)
        {
            case Effects.quickSceneChangeExpand:
                effect[0].SetActive(true);
                break;

            case Effects.quickSceneChangeCollapse:
                effect[0].GetComponent<Animator>().Play("Collapse");
                break;
        }
    }

    public async void CameraCloseOpen()
    {
        _player.playerMovement.lockMovement = true;

        ChangeCameraEffect(CameraEffects.Effects.quickSceneChangeExpand);

        await Task.Delay(500);

        CameraController.Instance.cameraEffects.ChangeCameraEffect(CameraEffects.Effects.quickSceneChangeCollapse);

        _player.playerMovement.lockMovement = false;
    }
}
