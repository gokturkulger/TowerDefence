using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Debug.Log(collision.gameObject.name);
            // Çarpýþmadan sonra mermiyi yok edelim
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Health enemyHealth = other.gameObject.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
        Debug.Log(other.gameObject.name);
        // Çarpýþmadan sonra mermiyi yok edelim
        Destroy(gameObject);
    }
    
}
