using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float startinghealth = 50f;
    public float currenthealth;
    bool isDead = false;
    [Header("UI STUFF")]
    public Image healthBar;

    void Start()
    {
        currenthealth = startinghealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        currenthealth -= amount;

        healthBar.fillAmount = currenthealth / startinghealth;

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
