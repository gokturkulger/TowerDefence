using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;
 // UI yöneticisine eriþim için bir referans.
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("Game Manager not found in the scene!");
        }
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die(); // Örneðin, düþman ölüm iþlevi burada çaðrýlabilir.
        }
    }

    void Die()
    {
        // Ölüm iþlemleri burada yapýlabilir.
        if (gameObject.CompareTag("Player"))
        {
            // Eðer ölen nesne bir oyuncu ise UI'yi aç.
            gameManager.OpenGameOverUI();
            // Oyunu durdurabilir veya diðer iþlemler yapabilirsiniz.
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            // Eðer ölen nesne bir düþman ise puan ekle.
          gameManager.AddScore(100); // Örneðin, 100 puan ekleyebiliriz.
        }

        Destroy(gameObject);
    }
}
