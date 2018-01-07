using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision: MonoBehaviour {
    #region Variables
    public CameraFollowPlayer thisScript;
    public Transform player;
    private float dist;
    #endregion

    void FixedUpdate()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        //Debug.Log(Vector3.Distance(player.position, transform.position));
        if (dist > 12)
        {
            thisScript.enabled = true;
            Debug.Log("Follow");
        }
        else
        {
            thisScript.enabled = false;
            Debug.Log("Dont follow");

        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enviroment")
        {
            thisScript.enabled = false;
            Debug.Log("Dont follow");

        }

    }
}