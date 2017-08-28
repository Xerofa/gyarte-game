using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer: MonoBehaviour {
    #region Variables
    public Transform player;
    public Transform cameraFollow;
    float checkForPlayer = 0;

    public float cameraOffsetX;
    public float cameraOffsetY;
    public float cameraOffsetZ;
    #endregion
	void Start()
    {
        if(!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (player)
            {
                Debug.Log("Found player");
            }
        }
    }
    void FixedUpdate () 
    {
        if(player == null)
        {
            FindPlayer();
            return;
        }

        cameraFollow.position = new Vector3(player.position.x + cameraOffsetX, 0 + cameraOffsetY, player.position.z / 1.5f + cameraOffsetZ);
    }

    void FindPlayer()
    {
        if(checkForPlayer <= Time.time)
        {
           GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                player = searchResult.transform;
            checkForPlayer = Time.time + 0.5f;
        }
    }

}