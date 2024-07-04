using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // Projektil prefabý
    public Transform spawnPoint;         // Spawn noktasý
    public WeopanSystem weaponSystem;    // Silah sistemi ayarlarý
            // Ateþ menzili

    private float nextFireTime = 0f;     // Bir sonraki ateþ zamaný
    private Transform target;
    private string targetTag;


    void Start()
    {
        // Taretin tag'ine göre hedef tag'ini belirle
        if (gameObject.CompareTag("Enemy"))
        {
            GameObject spawnPointObj = GameObject.FindGameObjectWithTag("SpawnPoint");
            if (spawnPointObj != null)
            {
                spawnPoint = spawnPointObj.transform;
            }
            targetTag = "Target";
        }
        else
        {
            targetTag = "Enemy";
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        GameObject spawnPointObj = GameObject.FindGameObjectWithTag("SpawnPoint");
        if (spawnPointObj == null)  
        {

            if (gameObject.CompareTag("Enemy"))
            {
                spawnPoint = spawnPointObj.transform;
            }
            targetTag = "Target";
        }
        FindNearestTarget();  // En yakýndaki düþmaný bul
        RotateTowardsTarget();
        if (target != null && Time.time >= nextFireTime)  // Hedef varsa ve ateþ zamaný geldiyse
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= weaponSystem.fireRange)  // Hedef menzil içinde mi?
            {
              
                Fire();  // Ateþ et
                nextFireTime = Time.time + 1f / weaponSystem.fireRate;
            }
        }
    }

    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance && distanceToEnemy <= weaponSystem.fireRange)  // Menzil içinde mi?
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }

        target = closestEnemy;
    }

    void RotateTowardsTarget()
    {
       
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            direction.y = 0;  // Y ekseninde dönüþü engelle
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position), 5 * Time.deltaTime);
        }
    }

    void Fire()
    {
        Vector3 targetPosition = target.position;
        targetPosition.y += 1.5f;  // Sadece y ekseninde ofset ekle
      
        // Projektili spawn pozisyonunda oluþtur
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        // Projektilin hedef objeye doðru dönmesini saðlar
        projectile.transform.LookAt(targetPosition);

        // Projektil bileþenini al ve hasar deðerini ayarla
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.damage = weaponSystem.firePower;
        }
      
        // Projektilin hedef objeye doðru hareket etmesi için kuvvet uygular

        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 3000);
        Destroy(projectile,1);
    }
}
