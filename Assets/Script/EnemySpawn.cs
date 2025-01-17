using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public Transform spawnPoint; // Tek bir spawn noktas�
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
        if (currentEnemies<=maxEnemies/2)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
       
        }
        if ( currentEnemies>maxEnemies/2 && currentEnemies <= maxEnemies)
        {
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
