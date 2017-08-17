using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    #region Variables
    
    public static float horizontalSpeed = 10f;
    public static float verticalSpeed = 10f;

    public static float airHorizontalSpeed = 7.5f;
    public static float airVerticalSpeed = 7.5f;

    public float currentHSpeed;
    public float currentVSpeed;

    public float jumpSpeed;

    private float canJump =0f;

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
            Debug.Log("Jump!");
            canJump = Time.time + 1.5f;
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
