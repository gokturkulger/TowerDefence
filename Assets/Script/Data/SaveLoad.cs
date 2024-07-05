using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;

    public GameData gameData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savegame.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savegame.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            gameData = (GameData)formatter.Deserialize(stream);
            stream.Close();
        }
        else
        {
            Debug.Log("Kayýtlý oyun bulunamadý. Yeni bir oyun baþlatýlýyor.");
            gameData = new GameData(); // Yeni bir oyun verisi oluþturabilirsiniz
        }
    }

    public void ResetGame()
    {
        gameData = new GameData();
        SaveGame(); // Sýfýrladýktan sonra kaydetmeyi unutmayýn
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
