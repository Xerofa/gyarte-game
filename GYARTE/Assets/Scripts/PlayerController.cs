using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    #region Variables

    public static float movementSpeed = 7.5f;
    public static float airMovementSpeed = 5f;
    public float currentMovementSpeed;
    public float jumpSpeed;
    public float fallSpeed;
    private float canJump =0f;
    public float jumpRate;
    private bool isInAir;
    public Rigidbody rb;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentMovementSpeed = movementSpeed;
        isInAir = false;
    }

	void FixedUpdate () 
	{      
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * currentMovementSpeed, 0f, 0f, Space.World);
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * currentMovementSpeed, Space.World);
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && Time.time > canJump)
        {
            rb.AddForce (transform.up * jumpSpeed, ForceMode.Impulse);
            rb.AddForce(-transform.up * fallSpeed, ForceMode.Impulse);
            Debug.Log("Jump!");
            canJump = Time.time + jumpRate;
            isInAir = true;
            currentMovementSpeed = airMovementSpeed;
        }      
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enviroment")
        {
            isInAir = false;
            currentMovementSpeed = movementSpeed;
        }
    }   
}
