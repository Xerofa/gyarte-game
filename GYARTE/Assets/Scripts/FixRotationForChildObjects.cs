using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotationForChildObjects: MonoBehaviour {
    #region Variables
    Quaternion rotation;
    #endregion

    void Start () 
   {
        rotation = transform.rotation;
   }
	
   void LateUpdate () 
   {
        transform.rotation = rotation;
    }

}