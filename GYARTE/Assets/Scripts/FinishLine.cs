using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine: MonoBehaviour {
    #region Variables
    public Transform player;
    public GameObject completeLevelUI;
    public PlayerRangedAttack pRA;
    public PlayerMeleeAttack pMA;
    #endregion

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.LevelComplete();
            completeLevelUI.SetActive(true);
            pRA.GetComponent<PlayerRangedAttack>().enabled = false;
            pMA.GetComponent<PlayerMeleeAttack>().enabled = false;
        }
    }

}