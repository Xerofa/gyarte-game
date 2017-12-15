using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points: MonoBehaviour {
    #region Variables
    public GameObject pickupPointsEffect;
    public Text scoreText;
    public int amountPickedUp;
    #endregion

    void Start()
    {
        amountPickedUp = 0;
        scoreText.text = amountPickedUp.ToString();
    }

  void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PickupPoints();
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