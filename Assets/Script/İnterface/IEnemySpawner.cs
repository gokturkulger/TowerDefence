using UnityEngine;

public interface IEnemySpawner
{
    void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint);
}

