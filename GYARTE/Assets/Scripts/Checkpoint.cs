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
    [Header("Misc")]
    public AudioManager aM;
    #endregion

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        redcheckPointModel.SetActive(true);
        greencheckPointModel.SetActive(false);
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }

   void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player" && !alreadyPlayed)
        {
            gameManager.currentSpawnPoint = gameObject;
            // Debug.Log("Entered " + gameManager.currentSpawnPoint + "!!");
            aM.Play("Checkpoint");
            alreadyPlayed = true;
            redcheckPointModel.SetActive(false);
            greencheckPointModel.SetActive(true);
            GameManager.remainingLives++;
        }
    }
}