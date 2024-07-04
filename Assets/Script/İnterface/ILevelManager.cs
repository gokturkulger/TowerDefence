using UnityEngine;

public interface ILevelManager
{
    int CurrentLevel { get; }
    Transform SpawnPoint { get; }
    void LoadNextLevel();
}

