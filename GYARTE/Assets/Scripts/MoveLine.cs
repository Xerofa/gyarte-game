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
   }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enviroment")
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(gameObject);
        }
    }


}