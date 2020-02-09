using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1f;
    public float baseSpeed = 10f;
    [HideInInspector] //on spawn speed is set
    public float speed;

    void Start() {
        speed = baseSpeed;
    }
    public void TakeDamage(float damageTaken) {
        health -= damageTaken;

        if(health <= 0) Die();
    }

    public void Slow(float percentSlow) {
        speed = baseSpeed * percentSlow;
    }

    void Die() {
        Destroy(gameObject);
    }
}
