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

        if (currenthealth <= 0f)
        {
            GameManager.KillPlayer(this);
            isDead = true;
        }
    }
}
