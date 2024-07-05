using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;


    public int currentLevel = 1;
    public int maxEnemiesForCurrentLevel = 10; 

    void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        switch (PlayerPrefs.GetInt("Level"))
        {
            case 1:
                maxEnemiesForCurrentLevel = 4;
                break;
            case 2:
                maxEnemiesForCurrentLevel = 8;
                break;
            // Diðer seviyelere göre maxEnemiesForCurrentLevel deðerlerini ayarlayýn.
            default:
                maxEnemiesForCurrentLevel = 10;
                break;
        }
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("Level", currentLevel);
        // Burada örneðin farklý seviyeler için farklý maksimum düþman sayýlarýný ayarlayabilirsiniz.
        switch (currentLevel)
        {
            case 1:
                maxEnemiesForCurrentLevel = 4;
                break;
            case 2:
                maxEnemiesForCurrentLevel = 8;
                break;
            // Diðer seviyelere göre maxEnemiesForCurrentLevel deðerlerini ayarlayýn.
            default:
                maxEnemiesForCurrentLevel = 10;
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RetryLevel()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public int GetMaxEnemiesForCurrentLevel()
    {
        return maxEnemiesForCurrentLevel;
    }
   
}
