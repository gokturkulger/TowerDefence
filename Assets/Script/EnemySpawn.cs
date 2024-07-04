using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public Transform spawnPoint; // Tek bir spawn noktasý
    public float spawnInterval = 5f;

    private float nextSpawnTime;
    private LevelManager levelManager;
    int currentEnemies;
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        levelManager = LevelManager.instance;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    public void SpawnEnemy()
    {
        int maxEnemies = levelManager.GetMaxEnemiesForCurrentLevel();
         currentEnemies++;
        if (maxEnemies/2==currentEnemies)
        {
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
            return;
        }
        if (currentEnemies < maxEnemies)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
