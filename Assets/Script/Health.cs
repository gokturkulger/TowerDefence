using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;
 // UI y�neticisine eri�im i�in bir referans.
    private GameManager gameManager;

    public int playerHealth;

    // Oyuncu verilerinin g�ncellenmesi i�in �rnek bir metod
   
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("Game Manager not found in the scene!");
        }
        currentHealth = maxHealth;
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(5);
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die(); 
        }
        Debug.Log(currentHealth+gameObject.name);
    }

    void Die()
    {
        // �l�m i�lemleri burada yap�labilir.
        if (gameObject.layer== LayerMask.NameToLayer("Player"))
        {
         
            gameManager.OpenGameOverUI();
           
        }
        else if (gameObject.CompareTag("Enemy"))
        {
          
          gameManager.
                AddScore(100); 
        }

        Destroy(gameObject);
    }

    //public void UpdatePlayerData(int score, int health)
    //{
    //    score = gameManager.GetScore();
    //    health = currentHealth;
    //}
}
