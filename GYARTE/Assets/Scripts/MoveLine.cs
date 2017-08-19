using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLine: MonoBehaviour {
    #region Variables
    public int moveSpeed;

    public Transform firePoint;

    #endregion
	
   void Update () 
   {
        transform.Translate(firePoint.transform.right * Time.deltaTime * moveSpeed);
        Destroy(this.gameObject, .16f);
   }

}