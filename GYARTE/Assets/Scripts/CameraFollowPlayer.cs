using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer: MonoBehaviour {
    #region Variables
    public Transform player;
    float checkForPlayer = 0;

    public Vector3 offset;
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

        transform.position = player.position + offset;
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