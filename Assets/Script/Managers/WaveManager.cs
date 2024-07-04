using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{ }
//    public EnemySpawn enemySpawnerA;
//    public EnemySpawn enemySpawnerB;
//    public float timeBetweenWaves = 10f;

//    private LevelManager levelManager;
//    private int currentWave = 0;

//    void Start()
//    {
//        levelManager = LevelManager.instance;
//        StartCoroutine(StartNextWave());
//    }

//    private IEnumerator StartNextWave()
//    {
//        yield return new WaitForSeconds(timeBetweenWaves);

//        currentWave++;
//        int maxEnemies = levelManager.GetMaxEnemiesForCurrentLevel();
//        int enemiesPerWaveA = maxEnemies / 2;
//        int enemiesPerWaveB = maxEnemies - enemiesPerWaveA; // Kalan düþmanlarý ikinci tür için kullan

//        StartCoroutine(SpawnEnemies(enemySpawnerA, enemiesPerWaveA));
//        StartCoroutine(SpawnEnemies(enemySpawnerB, enemiesPerWaveB));

//        yield return new WaitForSeconds(timeBetweenWaves);
//        StartCoroutine(StartNextWave());
//    }

//    private IEnumerator SpawnEnemies(EnemySpawn spawner, int count)
//    {
//        for (int i = 0; i < count; i++)
//        {
//            spawner.SpawnEnemy();
//            yield return new WaitForSeconds(spawner.spawnInterval);
//        }
//    }
//}
