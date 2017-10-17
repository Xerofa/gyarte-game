using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine: MonoBehaviour {
    #region Variables
    public GameObject player;
    public GameObject completeLevelUI;
    public PlayerRangedAttack pRA;
    public PlayerMeleeAttack pMA;
    public EnemyAI eAI;
    #endregion

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.LevelComplete();
            completeLevelUI.SetActive(true);
            if (pRA == null)
                return;
            pRA.GetComponent<PlayerRangedAttack>().enabled = false;
            pMA.GetComponent<PlayerMeleeAttack>().enabled = false;
            eAI.GetComponent<EnemyAI>().enabled = false;
        }
    }

}