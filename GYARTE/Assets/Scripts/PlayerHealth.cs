using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth: MonoBehaviour {
    #region Variables
    public float startinghealth = 100f;
    public float currenthealth;
    bool isDead = false;
    public EnemyAI eAI;
    public PlayerController pCO;
    public PlayerRangedAttack pRA;
    public PlayerMeleeAttack pMA;
    #endregion

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

   public void Die()
   {
        isDead = true;
        eAI.GetComponent<EnemyAI>().enabled = false;
        pCO.GetComponent<PlayerController>().enabled = false;
        pRA.GetComponent<PlayerRangedAttack>().enabled = false;
        pMA.GetComponent<PlayerMeleeAttack>().enabled = false;       
        Debug.Log("Game Over!");
        //Visa Game Over skärm, via ett GameManager!!
   }
}
