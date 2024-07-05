using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;
 // UI yöneticisine eriþim için bir referans.
    private GameManager gameManager;

    public int playerHealth;

    // Oyuncu verilerinin güncellenmesi için örnek bir metod
   
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
        // Ölüm iþlemleri burada yapýlabilir.
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
