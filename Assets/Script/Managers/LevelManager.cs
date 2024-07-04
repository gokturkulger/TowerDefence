using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int currentLevel = 1;
    public int maxEnemiesForCurrentLevel = 10; // Örnek maksimum düþman sayýsý

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
        // Burada örneðin farklý seviyeler için farklý maksimum düþman sayýlarýný ayarlayabilirsiniz.
        switch (currentLevel)
        {
            case 1:
                maxEnemiesForCurrentLevel = 10;
                break;
            case 2:
                maxEnemiesForCurrentLevel = 15;
                break;
            // Diðer seviyelere göre maxEnemiesForCurrentLevel deðerlerini ayarlayýn.
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
