using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uiManager;
    public GameObject winUI;
    public GameObject gameOverUI;
    private int enemyCount;
    private int score = 0;

    void Awake()
    {
      
        uiManager = FindFirstObjectByType<UIManager>();
        if (instance == null)
            instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        GetScore();
        // Score g�ncelleme i�lemleri burada yap�labilir.

        // UI g�ncellemesi i�in UIManager �zerinden �a�r� yapabiliriz
     uiManager.UpdateScoreUI(score);
    }

    public int GetScore()
    {
          enemyCount = FindAnyObjectByType<LevelManager>().maxEnemiesForCurrentLevel;
        if (enemyCount==(score/100))
        {
            OpenGameWinUI();
        }
        return score;
    }
    public void OpenGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public void OpenGameWinUI()
    {
        winUI.SetActive(true);
    }
  
   
}
