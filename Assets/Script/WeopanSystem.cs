using UnityEngine;

[CreateAssetMenu(fileName = "WeopanSystem", menuName = "Scriptable Objects/WeopanSystem")]
public class WeopanSystem : ScriptableObject
{
    public float fireRate;
    public int firePower;
    public float fireRange ;
    public GameObject spawnFirePoint;
    public float launchVelocity;
    public GameObject prefabBullet;
    [System.Serializable]
    public enum GunType
    {
        Meleee,
        Ranged,
        Bomb
    }
}
