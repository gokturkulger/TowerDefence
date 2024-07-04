using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;
 // UI y�neticisine eri�im i�in bir referans.
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
            Die(); // �rne�in, d��man �l�m i�levi burada �a�r�labilir.
        }
    }

    void Die()
    {
        // �l�m i�lemleri burada yap�labilir.
        if (gameObject.CompareTag("Player"))
        {
            // E�er �len nesne bir oyuncu ise UI'yi a�.
            gameManager.OpenGameOverUI();
            // Oyunu durdurabilir veya di�er i�lemler yapabilirsiniz.
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            // E�er �len nesne bir d��man ise puan ekle.
          gameManager.AddScore(100); // �rne�in, 100 puan ekleyebiliriz.
        }

        Destroy(gameObject);
    }
}
