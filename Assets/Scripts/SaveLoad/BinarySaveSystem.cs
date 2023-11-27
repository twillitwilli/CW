using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySaveSystem
{
    public static void SaveData(SaveData saveData, int saveFile)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string fileName = Application.persistentDataPath + "/" + "PlayerData" + saveFile;

        FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);

        formatter.Serialize(fileStream, saveData);

        fileStream.Close();
    }

    public static SaveData LoadData(int saveFile)
    {
        string fileName = Application.persistentDataPath + "/" + "PlayerData" + saveFile;

        if (File.Exists(fileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(fileName, FileMode.Open);

            SaveData loadedData = formatter.Deserialize(fileStream) as SaveData;

            fileStream.Close();

            return loadedData;
        }

        else return null; //File Not Found
    }

    public static void DeleteFileSave(int saveFile)
    {
        string fileName = Application.persistentDataPath + "/" + "PlayerData" + saveFile;

        if (File.Exists(fileName))
        {
            File.Delete(fileName);

            Debug.Log("File Deleted #" + saveFile);
        }
    }
}
