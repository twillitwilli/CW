using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool
        isLocked,
        lockCamera,
        unlockCamera,
        changeToInsideVolume,
        changeToOutsideVolume;

    [SerializeField]
    Vector3
        _newPlayerPosition,
        _lockCameraPosition;

    [SerializeField]
    GameObject[] _enableObjects;

    [SerializeField]
    GameObject[] _disableObjects;

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;

        if (!isLocked && collision.TryGetComponent<Player>(out player))
        {
            player.playerMovement.lockMovement = true;

            CameraController.Instance.cameraEffects.ChangeCameraEffect(CameraEffects.Effects.quickSceneChangeExpand);

            await Task.Delay(250);

            DisableObjects();

            EnableObjects();

            if (unlockCamera)
                CameraController.Instance.whichState = CameraController.CameraState.followPlayer;

            player.transform.position = _newPlayerPosition;

            if (lockCamera)
            {
                CameraController.Instance.whichState = CameraController.CameraState.lockCamera;
                CameraController.Instance.transform.position = _lockCameraPosition;
            }
                

            await Task.Delay(250);

            CameraController.Instance.cameraEffects.ChangeCameraEffect(CameraEffects.Effects.quickSceneChangeCollapse);

            player.playerMovement.lockMovement = false;

            AdjustVolume();
        }
    }

    private void EnableObjects()
    {
        if (_enableObjects.Length > 0)
        {
            foreach (GameObject obj in _enableObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    private void DisableObjects()
    {
        if (_disableObjects.Length > 0)
        {
            foreach (GameObject obj in _disableObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    public void AdjustVolume()
    {
        if (changeToInsideVolume)
            MusicManager.Instance.AdjustInsideVolume();

        if (changeToOutsideVolume)
            MusicManager.Instance.ReturnToOutsideVolume();
    }
}
