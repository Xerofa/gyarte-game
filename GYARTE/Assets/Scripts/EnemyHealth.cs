using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health = 50f;

    bool isDead = false;

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        health -= amount;


        if (health <= 0)
        {
            Die();
            isDead = true;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
