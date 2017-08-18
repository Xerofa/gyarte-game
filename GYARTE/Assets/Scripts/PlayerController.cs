using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    #region Variables
    
    public static float horizontalSpeed = 7.5f;
    public static float verticalSpeed = 7.5f;

    public static float airHorizontalSpeed = 5f;
    public static float airVerticalSpeed = 5f;

    public float currentHSpeed;
    public float currentVSpeed;

    public float jumpSpeed;
    public float fallSpeed;

    private float canJump =0f;
    public float jumpRate;

    private bool isInAir = false;

    #endregion

    public Rigidbody rb;
     
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHSpeed = horizontalSpeed;
        currentVSpeed = verticalSpeed;
    }

	void FixedUpdate () 
	{
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * currentHSpeed, 0f, 0f, Space.World);
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * currentVSpeed, Space.World);
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
            currentHSpeed = airHorizontalSpeed;
            currentVSpeed = airVerticalSpeed;
        }
       
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enviroment")
        {
            isInAir = false;
            currentHSpeed = horizontalSpeed;
            currentVSpeed = verticalSpeed;
        }
    }
    
}
