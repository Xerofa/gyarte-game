using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint: MonoBehaviour {
    #region Variables
    public GameManager gameManager;
    public Transform spawnPoint;
    public bool alreadyPlayed = false;
    #endregion

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

   void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player" && !alreadyPlayed)
        {
            gameManager.currentSpawnPoint = gameObject;
            Debug.Log("Entered " + gameManager.currentSpawnPoint + "!!");
            alreadyPlayed = true;
        }
    }
}