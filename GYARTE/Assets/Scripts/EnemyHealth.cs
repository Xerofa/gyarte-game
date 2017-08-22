using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float startinghealth = 50f;
    public float currenthealth;

    bool isDead = false;

    void Start()
    {
        currenthealth = startinghealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        currenthealth -= amount;

        if (currenthealth <= 0)
        {
            Die();           
        }
    }

    void Die()
    {

        isDead = true;
        Destroy(this.gameObject);
    }
}
