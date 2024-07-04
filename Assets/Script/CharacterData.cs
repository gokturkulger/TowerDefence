using UnityEngine;

public enum PlayerType
{
    CloseRange,
    FarRange
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public PlayerType playerType;
    public float closeRangeThreshold;
    public float closeRangeFireRate = 1f;
    public float farRangeFireRate = 0.5f;
    public float bombThrowRate = 0.2f;

    public GameObject closeRangeAttackPrefab;
    public GameObject farRangeAttackPrefab;
    public GameObject bombPrefab;
}
