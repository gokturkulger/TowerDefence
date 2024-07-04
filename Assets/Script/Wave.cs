using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class Wave
{
    public List<WaveEnemy> enemies; // Dalga içindeki düþmanlarýn listesi
    public float timeBetweenWaves = 10f; // Dalga arasý bekleme süresi
}

[System.Serializable]
public class WaveEnemy
{
    public GameObject enemyPrefab; // Düþman prefabý
    public int count; // Düþman sayýsý
    public float spawnInterval; // Düþmanlarýn arasýndaki spawn aralýðý
}

