using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    void OnCollisionEnter(Collision collision)
    {
      
    }
}
