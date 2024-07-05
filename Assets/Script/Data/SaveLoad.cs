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
            Debug.Log("Kay�tl� oyun bulunamad�. Yeni bir oyun ba�lat�l�yor.");
            gameData = new GameData(); // Yeni bir oyun verisi olu�turabilirsiniz
        }
    }

    public void ResetGame()
    {
        gameData = new GameData();
        SaveGame(); // S�f�rlad�ktan sonra kaydetmeyi unutmay�n
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
