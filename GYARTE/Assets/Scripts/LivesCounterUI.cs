using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounterUI: MonoBehaviour {
    #region Variables
    private Text livesText;
    #endregion

   void Start () 
   {
        livesText = GetComponent<Text>();
   }
	
   void Update () 
   {
        livesText.text = "Lives: " + GameManager.RemainingLives.ToString();
   }

}