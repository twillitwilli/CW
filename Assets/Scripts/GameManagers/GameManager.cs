using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using QTArts.AbstractClasses;

public class GameManager : MonoSingleton<GameManager>
{
    Player _player;
    public bool menuOpened { get; set; }
    public bool returningPlayer { get; set; }
    public int saveFile { get; set; }
    public int saveLocation { get; set; }
    public bool randomizerMode { get; set; }

    public GameObject GUI;

    private void Start()
    {
        GUI.SetActive(false);

        saveFile = -1;

        _player = Player.Instance;
    }

    public async void LoadSaveArea()
    {
        if (!GUI.activeSelf)
            GUI.SetActive(true);

        switch (saveLocation)
        {
            // Player House
            case 0:

                SceneManager.LoadScene("CotfalVillage");

                await Task.Delay(1000);

                SceneController.Instance.loadArea[0].SetActive(true);

                if (!returningPlayer)
                {
                    _player.transform.position = new Vector3(2.83f, -0.37f, 0);

                    _player.playerStats.Health = 1;
                    _player.playerStats.UpdateHealth();
                }

                break;

            // Cotfal Inn
            case 1:

                SceneManager.LoadScene("CotfalVillage");

                await Task.Delay(1000);

                SceneController.Instance.loadArea[1].SetActive(true);

                break;

            // Forest Temple
            case 2:

                SceneManager.LoadScene("ForestTemple");

                break;
        }
    }
}
