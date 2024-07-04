using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uiManager;
    public GameObject gameOverUI;

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
        // Score güncelleme iþlemleri burada yapýlabilir.

        // UI güncellemesi için UIManager üzerinden çaðrý yapabiliriz
     uiManager.UpdateScoreUI(score);
    }

    public int GetScore()
    {
        return score;
    }
    public void OpenGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
}
