using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour {
    #region Variables
    public static GameManager instance = null;
    public Transform player;
    public GameObject playerPrefab;
    public GameObject currentSpawnPoint;
    public int spawnDelay;
    public Image _healthBar;
    public static int remainingLives = 3;
    public GameObject gameOverUI;
    [Header("Misc")]
    public AudioManager aM;
    #endregion

    void Start () 
   {
        if(instance == null)
        {
            instance = this;
        }
          else if(instance != this)
          {
            Destroy(gameObject);
          }
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }
	
    void Update()
    {
        if (player == null)
            return;
    }

    public static int RemainingLives
    {
        get { return remainingLives; }
    }

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds (spawnDelay);
        Instantiate(playerPrefab, currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation);
        _healthBar.fillAmount = PlayerHealth.startinghealth;
    }

    public static void KillPlayer(PlayerHealth player)
    {
        Destroy(player.gameObject);
        //Debug.Log("Dead, respawning soon!");
        remainingLives--;
        //Debug.Log(remainingLives);
        if(remainingLives <= 0)
        {
            instance.EndGame();
        }
        else
        {
            instance.StartCoroutine(instance.RespawnPlayer());
        }
    }

    public void EndGame()
    {
        aM.Play("GameOver");
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
    }

    public static void LevelComplete()
    {
        Debug.Log("Level Completed!");
    }
}