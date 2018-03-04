using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController: MonoBehaviour {
    #region Variables
    public Animator anim;
    #endregion

   void Start () 
   {
        anim = GetComponent<Animator>();
   }
	
   void Update () 
   {
        if (Input.GetButton("Horizontal"))
        {
            anim.Play("PlayerWalk");
        }
        else if (Input.GetButton("Vertical"))
        {
            anim.Play("PlayerWalk");
        }
        else
        {
            anim.Play("PlayerIdle");
        }


   }

}