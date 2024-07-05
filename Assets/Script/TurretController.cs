using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;
    //public float range = 15f;
    public float rotationSpeed = 10f;
    //public GameObject projectilePrefab;
    public Transform firePoint;
    //public float fireRate = 1f;
    //public float projectileSpeed = 20f;

    private float fireCountdown = 0f;
    public WeopanSystem weaponSystem;

    void Update()
    {
        // Hedefi bul
        FindTarget();

        if (target == null)
            return;

        // Tareti hedefe d�nd�r
        RotateTowardsTarget();

        // Ate� et
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / weaponSystem.fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= weaponSystem.fireRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= weaponSystem.fireRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject projectileGO = Instantiate(weaponSystem.prefabBullet, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectileGO.GetComponent<Rigidbody>();
        Projectile projectileScript = projectileGO.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.damage = weaponSystem.firePower;
        }
        if (rb != null)
        {
            Vector3 direction = (target.position - firePoint.position).normalized;
            rb.linearVelocity = direction * weaponSystem.fireSpeed;
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, weaponSystem.fireRange);
    }
}
