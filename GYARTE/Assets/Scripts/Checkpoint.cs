using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint: MonoBehaviour {
    #region Variables
    public GameManager gameManager;
    public Transform spawnPoint;
    public bool alreadyPlayed = false;
    public GameObject greencheckPointModel;
    public GameObject redcheckPointModel;
    #endregion

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        redcheckPointModel.SetActive(true);
        greencheckPointModel.SetActive(false);
    }

   void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player" && !alreadyPlayed)
        {
            gameManager.currentSpawnPoint = gameObject;
            Debug.Log("Entered " + gameManager.currentSpawnPoint + "!!");
            alreadyPlayed = true;
            redcheckPointModel.SetActive(false);
            greencheckPointModel.SetActive(true);
        }
    }
}