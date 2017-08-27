using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine: MonoBehaviour {
    #region Variables
    public Transform player;
    #endregion

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.LevelComplete();
        }
    }

}