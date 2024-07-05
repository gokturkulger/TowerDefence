
using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI turretLevelText;
    public TextMeshProUGUI upgradeCostText;
    public GameObject upgradeButton;
    public Image turretSelectionIndicator;
    public TextMeshProUGUI currentLevel;
    public LevelManager levelManager;
    private Turret selectedTurret;

    public TextMeshProUGUI scoreText;
    void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        currentLevel.text = " Level"+ levelManager.currentLevel.ToString();
        if (instance == null)
        {
            instance = this;
        }
        UpdateScoreUI(GameManager.instance.GetScore());
    }
    public void UpdateScoreUI(int score)
    {
        // TextMeshProUGUI nesnesine skoru yazdýr
        scoreText.text = "Score: " + score.ToString();
    }
    public void ShowUpgradePanel(Turret turret)
    {
        selectedTurret = turret;

        // UI üzerinde seçilen taretin bilgilerini göster
        turretLevelText.text = "Level: " + turret.Level.ToString();
        upgradeCostText.text = "Upgrade Cost: " + turret.GetUpgradeCost().ToString();

        // Upgrade butonunu göster
        upgradeButton.SetActive(true);

        // Seçilen taretin materyalini deðiþtir
        if (selectedTurret != null)
        {
            selectedTurret.SetSelectedMaterial();
        }
    }

    public void HideUpgradePanel()
    {
        // Upgrade panelini gizle
        upgradeButton.SetActive(false);

        // Seçili taretin materyalini varsayýlan haline getir
        if (selectedTurret != null)
        {
            selectedTurret.ResetMaterial();
        }

        selectedTurret = null;
    }

    public void UpgradeTurret()
    {
        if (selectedTurret != null && GameManager.instance != null)
        {
            int upgradeCost = selectedTurret.GetUpgradeCost();

            if (GameManager.instance.GetScore() >= upgradeCost)
            {
                // Yeterli skor varsa turret'ý yükselt
                selectedTurret.Upgrade();
                GameManager.instance.AddScore(-upgradeCost);
                HideUpgradePanel(); // Upgrade panelini gizle
            }
            else
            {
                Debug.Log("Not enough score to upgrade turret!");
            }
        }
    }
}

