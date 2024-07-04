using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int currentLevel = 1;
    public int maxEnemiesForCurrentLevel = 10; // �rnek maksimum d��man say�s�

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        // Burada �rne�in farkl� seviyeler i�in farkl� maksimum d��man say�lar�n� ayarlayabilirsiniz.
        switch (currentLevel)
        {
            case 1:
                maxEnemiesForCurrentLevel = 10;
                break;
            case 2:
                maxEnemiesForCurrentLevel = 15;
                break;
            // Di�er seviyelere g�re maxEnemiesForCurrentLevel de�erlerini ayarlay�n.
            default:
                maxEnemiesForCurrentLevel = 10;
                break;
        }
    }

    public int GetMaxEnemiesForCurrentLevel()
    {
        return maxEnemiesForCurrentLevel;
    }
}
