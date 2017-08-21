using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer: MonoBehaviour {
    #region Variables
    public Transform player;
    public Transform cameraFollow;

    public float cameraOffsetX;
    public float cameraOffsetY;
    public float cameraOffsetZ;
    #endregion
	
   void Update () 
   {
        cameraFollow.position = new Vector3(player.position.x + cameraOffsetX, 0 + cameraOffsetY, player.position.z / 2 + cameraOffsetZ);
   }

}