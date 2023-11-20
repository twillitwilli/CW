using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public bool isDestroyed { get; private set; }

    public enum SpawnableObjects
    {
        jar,
        chest,
        rock
    }

    public SpawnableObjects spawnType;

    GameObject _currentSpawnedObj;

    public async void OnEnable()
    {
        await Task.Delay(500);

        SpawnObject();
    }

    private void SpawnObject()
    {
        if (!isDestroyed || _currentSpawnedObj == null)
        {
            switch (spawnType)
            {
                case SpawnableObjects.jar:

                    _currentSpawnedObj = JarPool.Instance.GetObject();
                    _currentSpawnedObj.transform.position = transform.position;

                    break;
            }
        }
    }
}
