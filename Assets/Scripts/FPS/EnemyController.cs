using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
}
