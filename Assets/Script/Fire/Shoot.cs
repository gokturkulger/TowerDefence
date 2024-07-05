using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // Projektil prefabý
    public Transform spawnPoint;         // Spawn noktasý
    public WeopanSystem weaponSystem;    // Silah sistemi ayarlarý
            // Ateþ menzili

    private float nextFireTime = 0f;     // Bir sonraki ateþ zamaný
    public Transform target;
    private string targetTag;


    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("SpawnPoint"))
            {
                spawnPoint = child;
            }
        }

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
        if (spawnPoint == null)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.CompareTag("SpawnPoint"))
                {
                    spawnPoint = child;
                }
            }
        }
        FindNearestTarget();  // En yakýndaki düþmaný bul
        RotateTowardsTarget();
        if (target != null && Time.time >= nextFireTime && target.tag!=this.gameObject.tag)  // Hedef varsa ve ateþ zamaný geldiyse
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
      
      
        

        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = enemy.transform;
                minDist = dist;
                target = enemy.transform;
            }
        }
    }

    void RotateTowardsTarget()
    {
       
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            direction.y = 0;  
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(target.localPosition), 5 * Time.deltaTime);
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
