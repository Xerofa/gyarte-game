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
    [Header("Misc")]
    public AudioManager aM;

    void Start()
    {
        currenthealth = startinghealth;
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
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
            aM.Play("EnemyDead");
        }
        else
        {
            aM.Play("EnemyTakeDamage");
        }
    }

    void Die()
    {
        isDead = true;
        Destroy(this.gameObject);
        
    }
}
