using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points: MonoBehaviour {
    #region Variables
    public GameObject pickupPointsEffect;
    public Text scoreText;
    public static int amountPickedUp;
    [Header("Misc")]
    public AudioManager aM;
    #endregion

    void Start()
    {
        amountPickedUp = 0;
        scoreText.text = amountPickedUp.ToString();
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }

  void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PickupPoints();
            aM.Play("CoinPickup");
        }
    }

    void PickupPoints()
    {
        Instantiate(pickupPointsEffect, transform.position, transform.rotation);
        amountPickedUp++;
        scoreText.text = amountPickedUp.ToString();

        Destroy(gameObject);
    }

}