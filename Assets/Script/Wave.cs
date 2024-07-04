using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class Wave
{
    public List<WaveEnemy> enemies; // Dalga i�indeki d��manlar�n listesi
    public float timeBetweenWaves = 10f; // Dalga aras� bekleme s�resi
}

[System.Serializable]
public class WaveEnemy
{
    public GameObject enemyPrefab; // D��man prefab�
    public int count; // D��man say�s�
    public float spawnInterval; // D��manlar�n aras�ndaki spawn aral���
}

