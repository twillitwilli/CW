using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnteredVillageFirstTime : MonoBehaviour
{
    [SerializeField]
    Vector3 _newPlayerPosition;

    [SerializeField]
    GameObject _door;

    [SerializeField]
    GameObject[] _enableObjects;

    [SerializeField]
    GameObject[] _disableObjects;

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;

        if (collision.gameObject.TryGetComponent<Player>(out player))
        {
            player.playerMovement.lockMovement = true;

            CameraController.Instance.cameraEffects.ChangeCameraEffect(CameraEffects.Effects.quickSceneChangeExpand);

            await Task.Delay(500);

            DisableObjects();

            EnableObjects();

            player.transform.position = _newPlayerPosition;

            await Task.Delay(1000);

            CameraController.Instance.cameraEffects.ChangeCameraEffect(CameraEffects.Effects.quickSceneChangeCollapse);

            MusicManager.Instance.ChangeMusicClip(0);

            CameraController.Instance.PlayCutScene(CameraController.CutScene.enteredCotfalVillage);

            _door.SetActive(true);

            Destroy(gameObject);
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
}
