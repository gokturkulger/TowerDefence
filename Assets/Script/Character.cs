using UnityEngine;

public class Character 
{
    [SerializeField] float health;
    [SerializeField] float speed;
    [System.Serializable]
    public enum TypeOfCharecter
    {
      
        Player,
        Enemy
    }
    //[SerializeField] 
    //[SerializeField]

}
